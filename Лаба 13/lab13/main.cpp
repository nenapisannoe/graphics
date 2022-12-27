
#include "camera.h"
#include "shaders.h"


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

using namespace std;

int VERTICES;

GLuint VBO;
GLuint Program;
GLuint texture_t1;
GLuint texture_t2;
GLuint texture_t3;
GLuint texture_t4;
GLuint texture_t5;
GLuint texture_t6;
GLuint texture_t7;

GLint A_vertex;
GLint A_uvs;
GLint A_vp;
GLint A_offsets;

Camera cam;
vector<glm::vec4> offsets;

vector<float> speeds;
vector<float> speeds_axis;

struct Vertex
{
	// Координаты
	GLfloat x;
	GLfloat y;
	GLfloat z;

	// Координаты текстуры
	GLfloat s;
	GLfloat t;
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

void load_obj(const char* filename, vector<Vertex>& out)
{
	vector<glm::vec3> vertices;
	vector<glm::vec3> normals;
	vector<glm::vec2> uvs;

	ifstream in(filename, ios::in);
	if (!in)
	{
		cerr << "Can't open obj " << filename << endl;
		return;
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
			vertices.push_back(v);
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
			Vertex ve1 = { vertices[v1 - 1].x, vertices[v1 - 1].y, vertices[v1 - 1].z, uvs[uv1 - 1].x, uvs[uv1 - 1].y };
			Vertex ve2 = { vertices[v2 - 1].x, vertices[v2 - 1].y, vertices[v2 - 1].z, uvs[uv2 - 1].x, uvs[uv2 - 1].y };
			Vertex ve3 = { vertices[v3 - 1].x, vertices[v3 - 1].y, vertices[v3 - 1].z, uvs[uv3 - 1].x, uvs[uv3 - 1].y };
			out.push_back(ve1);
			out.push_back(ve2);
			out.push_back(ve3);
		}
	}
}


void Init()
{
	speeds = { 0.00, 0.002, 0.003, 0.004, 0.005, 0.006, 0.007 };
	speeds_axis = {	0.01, 0.04, 0.06, 0.08, 0.1, 0.12, 0.14	};
	offsets = { {0, 0.3, 0, 0},
				{1, 0.03504, 0, 0},
				{2, 0.08691, 0, 0},
				{3, 0.09149, 0, 0},
				{4, 0.04868, 0, 0},
				{5, 0.10038, 0, 0},
				{6, 0.03626, 0, 0},
	};
	glEnable(GL_DEPTH_TEST);
	InitShader();
	InitVBO();
	InitTextures();
}

void Rotate()
{
	for (int i = 0; i < offsets.size(); i++)
	{
		offsets[i].z = fmod(offsets[i].z + speeds_axis[i], 2 * M_PI);
		offsets[i].w = fmod(offsets[i].w + speeds[i], 2 * M_PI);
	}
}

int main()
{
	sf::Window window(sf::VideoMode(1000, 1000), "LAB 13", sf::Style::Default, sf::ContextSettings(24));
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
				// Поворачиваем камеру
				if (event.key.code == sf::Keyboard::Up)
				{
					cam.Pitch_Plus();
				}
				else if (event.key.code == sf::Keyboard::Down)
				{
					cam.Pitch_Minus();
				}
				else if (event.key.code == sf::Keyboard::Right)
				{
					cam.Yaw_Plus();
				}
				else if (event.key.code == sf::Keyboard::Left)
				{
					cam.Yaw_Minus();
				}

				// Двигаем камеру
				else if (event.key.code == sf::Keyboard::W)
				{
					cam.Cam_Forward();
				}
				else if (event.key.code == sf::Keyboard::S)
				{
					cam.Cam_Bacward();
				}
				else if (event.key.code == sf::Keyboard::A)
				{
					cam.Cam_Left();
				}
				else if (event.key.code == sf::Keyboard::D)
				{
					cam.Cam_Right();
				}

				// Сбросить к изначальному
				else if (event.key.code == sf::Keyboard::F10)
				{
					cam.Reset();
				}
			}

		}
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		Rotate();
		Draw(window);
		window.display(); 
	}
}

void InitVBO()
{
	glGenBuffers(1, &VBO); 
	vector<Vertex> data;
	load_obj("teapot.obj", data);
	VERTICES = data.size();
	glBindBuffer(GL_ARRAY_BUFFER, VBO); 
	glBufferData(GL_ARRAY_BUFFER, VERTICES * sizeof(Vertex), data.data(), GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	checkOpenGLerror();
}

void InitTextures()
{
	LoadTexture(GL_TEXTURE0, texture_t1, "textures/sun.png");
	LoadTexture(GL_TEXTURE1, texture_t2, "textures/field.png");
	LoadTexture(GL_TEXTURE2, texture_t3, "textures/venus.jpg");
	LoadTexture(GL_TEXTURE3, texture_t4, "textures/earth.jpg");
	LoadTexture(GL_TEXTURE4, texture_t5, "textures/ruby.jpg");
	LoadTexture(GL_TEXTURE5, texture_t6, "textures/galaxy.jpg");
	LoadTexture(GL_TEXTURE6, texture_t7, "textures/saturn.jpeg");
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
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);

	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &FragShaderSource, NULL);
	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	ShaderLog(fShader);

	Program = glCreateProgram();

	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	glLinkProgram(Program);
	int link;
	glGetProgramiv(Program, GL_LINK_STATUS, &link);
	if (!link)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	LoadAttrib(Program, A_vertex, "coord");
	LoadAttrib(Program, A_uvs, "uv");
	LoadUniform(Program, A_vp, "veiw_point");
	LoadUniform(Program, A_offsets, "offsets");
	checkOpenGLerror();
	glUseProgram(Program);
	GLint textures[] = { 0, 1, 2, 3, 4, 5, 6 };
	glUniform1iv(glGetUniformLocation(Program, "tex"), 7, textures);
	glUseProgram(0);
}

void Draw(sf::Window& window)
{
	glUseProgram(Program);
	glUniformMatrix4fv(A_vp, 1, GL_FALSE, glm::value_ptr(cam.View_Point()));
	glUniform4fv(glGetUniformLocation(Program, "offsets"), 7, glm::value_ptr(offsets[0]));
	glEnableVertexAttribArray(A_vertex);
	glEnableVertexAttribArray(A_uvs);
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glVertexAttribPointer(A_vertex, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (GLvoid*)0);
	glVertexAttribPointer(A_uvs, 2, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArraysInstanced(GL_TRIANGLES, 0, VERTICES, 10);
	glDisableVertexAttribArray(A_vertex);
	glDisableVertexAttribArray(A_uvs);
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
	glDeleteBuffers(1, &VBO);
}

void ReleaseShader()
{
	glUseProgram(0); 
	glDeleteProgram(Program);
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
		std::cout << "OpenGL error: " << errString << std::endl;
	}
}