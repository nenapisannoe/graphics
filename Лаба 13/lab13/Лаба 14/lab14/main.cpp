
#include "camera.h"
#include "lights.h"

#include <gl/glew.h>
#include <gl/GL.h>
#include <gl/GLU.h>
#include <SFML/Graphics.hpp>
#include <SFML/OpenGL.hpp>

#include <iostream>
#include <vector>
#include <corecrt_math_defines.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <stdio.h>
#include <string>
#include <cstring>
#include <sstream>
#include <fstream>
#include <array>
#include <locale>

using namespace std;

Camera cam;

bool test = true;

array<int, 6> VERTIXES;
array<GLuint, 6> Objects;
array<GLuint, 6> Programs;
array<GLuint, 6> textures;

GLint Phong_coord;
GLint Phong_texcoord;
GLint Phong_normal;
GLint Phong_View_Point;
GLint Phong_viewPos;

GLint Toon_coord;
GLint Toon_texcoord;
GLint Toon_normal;
GLint Toon_View_Point;
GLint Toon_viewPos;

GLint Bidir_coord;
GLint Bidir_texcoord;
GLint Bidir_normal;
GLint Bidir_View_Point;
GLint Bidir_viewPos;

Point_Light pl;
Dir_Light dl;
Spot_Light sl;
Material mat;

struct Vertex
{
	// Координаты
	GLfloat x;
	GLfloat y;
	GLfloat z;

	// Координаты текстур
	GLfloat s;
	GLfloat t;

	// Нормали
	GLfloat nx;
	GLfloat ny;
	GLfloat nz;
};

void checkOpenGLerror();
void ShaderLog(unsigned int shader);
void InitShader();
void LoadAttrib(GLuint prog, GLint& attrib, const char* attr_name);
void LoadUniform(GLuint prog, GLint& attrib, const char* attr_name);
void LoadTexture(GLenum tex_enum, GLuint& tex, const char* path);
void InitVBO();
void InitTextures();
void Init();
void Draw(sf::Window& window);
void ReleaseShader();
void ReleaseVBO();
void Release();

int load_obj(const char* filename, vector<Vertex>& out)
{
	vector<glm::vec3> VERTIXES;
	vector<glm::vec3> normals;
	vector<glm::vec2> uvs;

	ifstream in(filename, ios::in);
	if (!in)
	{
		cerr << "Can't open obj " << filename << endl;
		return 0;
	}

	string line;
	while (getline(in, line))
	{
		string s = line.substr(0, 2);
		if (s == "v ")
		{
			istringstream s(line.substr(2));
			glm::vec3 v;
			s >> v.x;
			s >> v.y;
			s >> v.z;
			VERTIXES.push_back(v);
		}
		else if (s == "vt")
		{
			istringstream s(line.substr(3));
			glm::vec2 uv;
			s >> uv.x;
			s >> uv.y;
			uvs.push_back(uv);
		}
		else if (s == "vn")
		{
			istringstream s(line.substr(3));
			glm::vec3 n;
			s >> n.x;
			s >> n.y;
			s >> n.z;
			normals.push_back(n);
		}
		else if (s == "f ")
		{
			istringstream s(line.substr(2));
			string s1, s2, s3;
			s >> s1;
			s >> s2;
			s >> s3;
			unsigned int v1, v2, v3, uv1, uv2, uv3, n1, n2, n3;
			sscanf_s(s1.c_str(), "%d/%d/%d", &v1, &uv1, &n1);
			sscanf_s(s2.c_str(), "%d/%d/%d", &v2, &uv2, &n2);
			sscanf_s(s3.c_str(), "%d/%d/%d", &v3, &uv3, &n3);
			Vertex ve1 = { VERTIXES[v1 - 1].x, VERTIXES[v1 - 1].y, VERTIXES[v1 - 1].z, uvs[uv1 - 1].x, -uvs[uv1 - 1].y, normals[n1 - 1].x, normals[n1 - 1].y, normals[n1 - 1].z };
			Vertex ve2 = { VERTIXES[v2 - 1].x, VERTIXES[v2 - 1].y, VERTIXES[v2 - 1].z, uvs[uv2 - 1].x, -uvs[uv2 - 1].y, normals[n2 - 1].x, normals[n2 - 1].y, normals[n2 - 1].z };
			Vertex ve3 = { VERTIXES[v3 - 1].x, VERTIXES[v3 - 1].y, VERTIXES[v3 - 1].z, uvs[uv3 - 1].x, -uvs[uv3 - 1].y, normals[n3 - 1].x, normals[n3 - 1].y, normals[n3 - 1].z };
			out.push_back(ve1);
			out.push_back(ve2);
			out.push_back(ve3);
		}
	}
	return out.size();
}

const GLchar** load_shader(const char* path)
{
	ifstream file(path, ios::in);
	string src;

	while (file.good())
	{
		string line;
		getline(file, line);
		src.append(line + "\n");
	}
	;
	char* out = new char[src.length() + 1];
	strcpy_s(out, src.length() + 1, src.c_str());
	return (const GLchar**)&out;
}

void Init()
{
	// Точечный
	pl.pos = glm::vec3(-3.12f, 8.27f, -2.83f);
	pl.ambient = glm::vec3(0.1f);
	pl.diffuse = glm::vec3(1.0f);
	pl.specular = glm::vec3(1.0f);
	pl.atten = glm::vec3(0.2f);

	// Направленный
	dl.direction = glm::vec3(0.0f, -1.0f, 0.0f);
	dl.ambient = glm::vec3(0.25f);
	dl.diffuse = glm::vec3(0.25f);
	dl.specular = glm::vec3(0.25f);

	// Прожекторный
	sl.pos = glm::vec3(-5.0f, -8.0f, -15.0f);
	sl.direction = glm::vec3(1.0f);
	sl.ambient = glm::vec3(1.0f);
	sl.diffuse = glm::vec3(1.0f);
	sl.specular = glm::vec3(1.0f);
	sl.cutoff = 12.5f;
	sl.atten = glm::vec3(0.1f, 0.1f, 0.1f);

	// Мтаериалы
	mat.ambient = glm::vec3(0.5f, 0.5f, 0.5f);
	mat.diffuse = glm::vec3(0.5f, 0.5f, 0.5f);
	mat.specular = glm::vec3(0.5f, 0.5f, 0.5f);
	mat.emission = glm::vec3(0.0f, 0.0f, 0.0f);
	mat.shininess = 1.0f;

	glEnable(GL_DEPTH_TEST);
	InitShader();
	InitVBO();
	InitTextures();
}

int main()
{
	setlocale(LC_ALL, "russian");
	sf::Window window(sf::VideoMode(1000, 1000), "LAB 14", sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true); 
	window.setActive(true); 
	glewInit(); 
	Init();
	bool paused_sun = false;
	bool paused_axis = false;

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed) 
			{
				window.close();
				Release();
				return 0;
			}
			else if (event.type == sf::Event::Resized)
			{
				glViewport(0, 0, event.size.width, event.size.height);
			}
			else if (event.type == sf::Event::KeyPressed)
			{
				// Поворот камеры
				if (event.key.code == sf::Keyboard::Up)
				{
					cam.Cam_Pitch_Plus();
				}
				if (event.key.code == sf::Keyboard::Down)
				{
					cam.Cam_Pitch_Minus();
				}
				if (event.key.code == sf::Keyboard::Right)
				{
					cam.Cam_Yaw_Plus();
				}
				if (event.key.code == sf::Keyboard::Left)
				{
					cam.Cam_Yaw_Minus();
				}

				// Сдвиг камеры
				if (event.key.code == sf::Keyboard::W)
				{
					cam.Cam_Forward();
				}
				if (event.key.code == sf::Keyboard::S)
				{
					cam.Cam_Bacward();
				}
				if (event.key.code == sf::Keyboard::A)
				{
					cam.Cam_Left();
				}
				if (event.key.code == sf::Keyboard::D)
				{
					cam.Cam_Right();
				}

				// Вернуть к изначальному
				if (event.key.code == sf::Keyboard::F10)
				{
					cam.Reset();
				}

				// Дебаг
				if (event.key.code == sf::Keyboard::Num1)
				{
					pl.Config();
				}
				if (event.key.code == sf::Keyboard::Num2)
				{
					dl.Config();
				}
				if (event.key.code == sf::Keyboard::Num3)
				{
					sl.Config();
				}
			}

		}
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
		Draw(window);
		window.display();
	}
}

void LoadObject(int i, const char* path)
{
	glGenBuffers(1, &Objects[i]);
	vector<Vertex> data;
	VERTIXES[i] = load_obj(path, data);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[i]);
	glBufferData(GL_ARRAY_BUFFER, VERTIXES[i] * sizeof(Vertex), data.data(), GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	checkOpenGLerror();
}

void InitVBO()
{
	LoadObject(0, "models/plane.obj");
	LoadObject(1, "models/cube.obj");
	LoadObject(2, "models/torus.obj");
	LoadObject(3, "models/teapot.obj");
	LoadObject(4, "models/cylinder.obj");
	LoadObject(5, "models/cube.obj");
}

void InitTextures()
{
	LoadTexture(GL_TEXTURE0, textures[0], "textures/field.png");
	LoadTexture(GL_TEXTURE1, textures[1], "textures/venus.jpg");
	LoadTexture(GL_TEXTURE2, textures[2], "textures/ruby.jpg");
	LoadTexture(GL_TEXTURE3, textures[3], "textures/sun.png");
	LoadTexture(GL_TEXTURE4, textures[4], "textures/galaxy.jpg");
	LoadTexture(GL_TEXTURE5, textures[5], "textures/saturn.jpeg");
}

void LoadAttrib(GLuint prog, GLint& attrib, const char* attr_name)
{
	attrib = glGetAttribLocation(prog, attr_name);
	if (attrib == -1)
	{
		std::cout << "could not bind attrib " << attr_name << std::endl;
		return;
	}
}

void LoadUniform(GLuint prog, GLint& attrib, const char* attr_name)
{
	attrib = glGetUniformLocation(prog, attr_name);
	if (attrib == -1)
	{
		std::cout << "could not bind uniform " << attr_name << std::endl;
		return;
	}
}

void LoadTexture(GLenum tex_enum, GLuint& tex, const char* path)
{
	glGenTextures(1, &tex);
	glActiveTexture(tex_enum);
	glBindTexture(GL_TEXTURE_2D, tex);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	sf::Image img;
	if (!img.loadFromFile(path))
	{
		std::cout << "could not load texture " << path << std::endl;
		return;
	}

	sf::Vector2u size = img.getSize();
	int width = size.x;
	int height = size.y;
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, width, height, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glGenerateMipmap(GL_TEXTURE_2D);
}

void InitShader()
{
	GLuint PhongVShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(PhongVShader, 1, load_shader("shaders/phong.vert"), NULL);
	glCompileShader(PhongVShader);
	std::cout << "phong vertex shader \n";
	ShaderLog(PhongVShader);

	GLuint PhongFShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(PhongFShader, 1, load_shader("shaders/phong.frag"), NULL);
	glCompileShader(PhongFShader);
	std::cout << "phong fragment shader \n";
	ShaderLog(PhongFShader);

	GLuint ToonVShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(ToonVShader, 1, load_shader("shaders/toon.vert"), NULL);
	glCompileShader(ToonVShader);
	std::cout << "toon vertex shader \n";
	ShaderLog(ToonVShader);

	GLuint ToonFShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(ToonFShader, 1, load_shader("shaders/toon.frag"), NULL);
	glCompileShader(ToonFShader);
	std::cout << "toon fragment shader \n";
	ShaderLog(ToonFShader);

	GLuint BidirVShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(BidirVShader, 1, load_shader("shaders/bidir.vert"), NULL);
	glCompileShader(BidirVShader);
	std::cout << "bidir vertex shader \n";
	ShaderLog(BidirVShader);
	
	GLuint BidirFShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(BidirFShader, 1, load_shader("shaders/bidir.frag"), NULL);
	glCompileShader(BidirFShader);
	std::cout << "bidir fragment shader \n";
	ShaderLog(BidirFShader);

	Programs[0] = glCreateProgram(); // Phong
	Programs[1] = glCreateProgram(); // Toon
	Programs[2] = glCreateProgram(); // Bidirectional

	glAttachShader(Programs[0], PhongVShader);
	glAttachShader(Programs[0], PhongFShader);
	glAttachShader(Programs[1], ToonVShader);
	glAttachShader(Programs[1], ToonFShader);
	glAttachShader(Programs[2], BidirVShader);
	glAttachShader(Programs[2], BidirFShader);
	
	glLinkProgram(Programs[0]);
	glLinkProgram(Programs[1]);
	glLinkProgram(Programs[2]);
	int link1, link2, link3;
	glGetProgramiv(Programs[0], GL_LINK_STATUS, &link1);
	glGetProgramiv(Programs[1], GL_LINK_STATUS, &link2);
	glGetProgramiv(Programs[2], GL_LINK_STATUS, &link3);
	if (!link1 || !link2 || !link3)
	{
		std::cout << "could not link shader program" << std::endl;
		return;
	}

	LoadAttrib(Programs[0], Phong_coord, "coord");
	LoadAttrib(Programs[0], Phong_texcoord, "texcoord");
	LoadAttrib(Programs[0], Phong_normal, "normal");
	LoadUniform(Programs[0], Phong_View_Point, "mvp");
	LoadUniform(Programs[0], Phong_viewPos, "viewPos");

	LoadAttrib(Programs[1], Toon_coord, "coord");
	LoadAttrib(Programs[1], Toon_texcoord, "texcoord");
	LoadAttrib(Programs[1], Toon_normal, "normal");
	LoadUniform(Programs[1], Toon_View_Point, "mvp");
	//LoadUniform(Programs[1], Toon_viewPos, "viewPos");

	LoadAttrib(Programs[2], Bidir_coord, "coord");
	LoadAttrib(Programs[2], Bidir_texcoord, "texcoord");
	LoadAttrib(Programs[2], Bidir_normal, "normal");
	LoadUniform(Programs[2], Bidir_View_Point, "mvp");

	checkOpenGLerror();
}

void Draw(sf::Window& window)
{
	GLuint tex_loc;

	// Пол
	glUseProgram(Programs[0]);
	tex_loc = glGetUniformLocation(Programs[0], "tex");
	pl.Load(Programs[0]);
	dl.Load(Programs[0]);
	sl.Load(Programs[0]);
	mat.Load(Programs[0]);
	glUniformMatrix4fv(Phong_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform3fv(Phong_viewPos, 1, glm::value_ptr(cam.Pos));
	glUniform1i(tex_loc, 0);
	glEnableVertexAttribArray(Phong_coord);
	glEnableVertexAttribArray(Phong_texcoord);
	glEnableVertexAttribArray(Phong_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[0]);
	glVertexAttribPointer(Phong_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Phong_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Phong_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[0]);
	glDisableVertexAttribArray(Phong_coord);
	glDisableVertexAttribArray(Phong_texcoord);
	glDisableVertexAttribArray(Phong_normal);
	glUseProgram(0);

	// Кубик 1
	glUseProgram(Programs[0]);
	tex_loc = glGetUniformLocation(Programs[0], "tex");
	pl.Load(Programs[0]);
	dl.Load(Programs[0]);
	sl.Load(Programs[0]);
	mat.Load(Programs[0]);
	glUniformMatrix4fv(Phong_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform3fv(Phong_viewPos, 1, glm::value_ptr(cam.Pos));
	glUniform1i(tex_loc, 1);
	glEnableVertexAttribArray(Phong_coord);
	glEnableVertexAttribArray(Phong_texcoord);
	glEnableVertexAttribArray(Phong_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[1]);
	glVertexAttribPointer(Phong_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Phong_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Phong_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[1]);
	glDisableVertexAttribArray(Phong_coord);
	glDisableVertexAttribArray(Phong_texcoord);
	glDisableVertexAttribArray(Phong_normal);
	glUseProgram(0);

	// Кольцо
	glUseProgram(Programs[0]);
	tex_loc = glGetUniformLocation(Programs[0], "tex");
	pl.Load(Programs[0]);
	dl.Load(Programs[0]);
	sl.Load(Programs[0]);
	mat.Load(Programs[0]);
	glUniformMatrix4fv(Phong_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform3fv(Phong_viewPos, 1, glm::value_ptr(cam.Pos));
	glUniform1i(tex_loc, 2);
	glEnableVertexAttribArray(Phong_coord);
	glEnableVertexAttribArray(Phong_texcoord);
	glEnableVertexAttribArray(Phong_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[2]);
	glVertexAttribPointer(Phong_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Phong_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Phong_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[2]);
	glDisableVertexAttribArray(Phong_coord);
	glDisableVertexAttribArray(Phong_texcoord);
	glDisableVertexAttribArray(Phong_normal);
	glUseProgram(0); 

	// Чайник
	glUseProgram(Programs[2]);
	tex_loc = glGetUniformLocation(Programs[2], "tex");
	pl.Load(Programs[2]);
	dl.Load(Programs[2]);
	sl.Load(Programs[2]);
	mat.Load(Programs[2]);
	glUniformMatrix4fv(Bidir_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform1i(tex_loc, 3);
	glEnableVertexAttribArray(Bidir_coord);
	glEnableVertexAttribArray(Bidir_texcoord);
	glEnableVertexAttribArray(Bidir_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[3]);
	glVertexAttribPointer(Bidir_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Bidir_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Bidir_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[3]);
	glDisableVertexAttribArray(Bidir_coord);
	glDisableVertexAttribArray(Bidir_texcoord);
	glDisableVertexAttribArray(Bidir_normal);
	glUseProgram(0);

	// Цилиндр
	glUseProgram(Programs[0]);
	tex_loc = glGetUniformLocation(Programs[0], "tex");
	pl.Load(Programs[0]);
	dl.Load(Programs[0]);
	sl.Load(Programs[0]);
	mat.Load(Programs[0]);
	glUniformMatrix4fv(Phong_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform3fv(Phong_viewPos, 1, glm::value_ptr(cam.Pos));
	glUniform1i(tex_loc, 4);
	glEnableVertexAttribArray(Phong_coord);
	glEnableVertexAttribArray(Phong_texcoord);
	glEnableVertexAttribArray(Phong_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[4]);
	glVertexAttribPointer(Phong_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Phong_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Phong_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[4]);
	glDisableVertexAttribArray(Phong_coord);
	glDisableVertexAttribArray(Phong_texcoord);
	glDisableVertexAttribArray(Phong_normal);
	glUseProgram(0);

	// Кубик 2
	glUseProgram(Programs[0]);
	tex_loc = glGetUniformLocation(Programs[0], "tex");
	pl.Load(Programs[0]);
	dl.Load(Programs[0]);
	sl.Load(Programs[0]);
	mat.Load(Programs[0]);
	glUniformMatrix4fv(Phong_View_Point, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform3fv(Phong_viewPos, 1, glm::value_ptr(cam.Pos));
	glUniform1i(tex_loc, 1);
	glEnableVertexAttribArray(Phong_coord);
	glEnableVertexAttribArray(Phong_texcoord);
	glEnableVertexAttribArray(Phong_normal);
	glBindBuffer(GL_ARRAY_BUFFER, Objects[5]);
	glVertexAttribPointer(Phong_coord, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(Phong_texcoord, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glVertexAttribPointer(Phong_normal, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_TRIANGLES, 0, VERTIXES[5]);
	glDisableVertexAttribArray(Phong_coord);
	glDisableVertexAttribArray(Phong_texcoord);
	glDisableVertexAttribArray(Phong_normal);
	glUseProgram(0);

	checkOpenGLerror();
}

void Release()
{
	ReleaseShader();
	ReleaseVBO();
}

void ReleaseVBO()
{
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	for (int i = 0; i < Objects.size(); i++)
	{
		glDeleteBuffers(1, &Objects[i]);
	}
}

void ReleaseShader()
{
	glUseProgram(0);
	for (int i = 0; i < Programs.size(); i++)
	{
		glDeleteProgram(Programs[i]);
	}
}

void ShaderLog(unsigned int shader)
{
	int infologLen = 0;
	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
	if (infologLen > 1)
	{
		int charsWritten = 0;
		std::vector<char> infoLog(infologLen);
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
		std::cout << "InfoLog: " << infoLog.data() << std::endl;
		exit(1);
	}
}

void checkOpenGLerror()
{
	GLenum errCode;
	const GLubyte* errString;
	if ((errCode = glGetError()) != GL_NO_ERROR)
	{
		errString = gluErrorString(errCode);
		std::cout << "OpenGL error: (" << errCode << ") " << errString << std::endl;
	}
}