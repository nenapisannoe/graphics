

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


#include "shaders.h"
#define STB_IMAGE_IMPLEMENTATION
#include "stb_image.h"

using namespace std;

enum class ShapeType
{
	Cube_task2 = 0,
	Cube_task3
};


#define blue   0.0, 0.0, 1.0, 1.0
#define white  1.0, 1.0, 1.0, 1.0
#define red    1.0, 0.0, 0.0, 1.0
#define green  0.0, 1.0, 0.0, 1.0

// ID шейдерной программы
GLuint Task2;
GLuint Task3;

GLuint texture1;
GLuint texture2;
GLint A2_mix_value;
GLint A3_mix_value;

// ID атрибута
GLint A2_vertex;
GLint A2_color;
GLint A2_texCoord;
GLint A2_affine;
GLint A2_proj;

GLint A3_vertex;
GLint A3_color;
GLint A3_texCoord;
GLint A3_affine;
GLint A3_proj;

// ID вершинного буфера
GLuint VBO;

// Матрицы аффиных преобразований
glm::mat4 matr;
// Матрица проекции
glm::mat4 proj;

// Смешивание
GLfloat mix_value = 0.3f;

// Структура для хранения вершин
struct Vertex
{
	// координаты
	GLfloat x;
	GLfloat y;
	GLfloat z;

	// цвета
	GLfloat r;
	GLfloat g;
	GLfloat b;
	GLfloat a;

	// текстуры
	GLfloat tex1;
	GLfloat tex2;
};

// Функция для проверки ошибок
void checkOpenGLerror();
void ShaderLog(unsigned int shader);

// Функция для загрузки шейдеров
void InitShader();
void LoadAttrib(GLuint prog, GLint& attrib, const char* attr_name);
void LoadUniform(GLuint prog, GLint& attrib, const char* attr_name);

// Функция для инициализации вершинного буфера
void InitVBO();
// Функция для инициализации ресурсов
void InitTextures();
void Init();
// Функция для отрисовки
void Draw(sf::Window& window);
// Функция для очистки шейдеров
void ReleaseShader();
// Функция для очистки вершинного буфера
void ReleaseVBO();
// Функция для очистки ресурсов
void Release();

using namespace std;

ShapeType shapetype = ShapeType::Cube_task2;


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

void Init()
{
	proj = glm::ortho(-1.0f, 1.0f, -1.0f, 1.0f, 0.1f, 100.0f);
	matr = glm::mat4(1.0f);
	//Включаем проверку глубины
	glEnable(GL_DEPTH_TEST);
	// Инициализируем шейдеры
	InitShader();
	// Инициализируем вершинный буфер
	InitVBO();
	InitTextures();
}

int main()
{
	sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true);
	window.setActive(true);
	glewInit(); 
	Init();
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
				// Поворот
				if (event.key.code == sf::Keyboard::I)
				{
					matr = glm::rotate(matr, 0.1f, glm::vec3(1.0f, 0.0f, 0.0f));
				}
				else if (event.key.code == sf::Keyboard::O)
				{
					matr = glm::rotate(matr, 0.1f, glm::vec3(0.0f, 1.0f, 0.0f));
				}
				else if (event.key.code == sf::Keyboard::P)
				{
					matr = glm::rotate(matr, 0.1f, glm::vec3(0.0f, 0.0f, 1.0f));
				}

				// Смешивание
				else if (event.key.code == sf::Keyboard::F3)
				{
					if (mix_value < 1.0f)
					{
						mix_value += 0.1f;
					}
				}
				else if (event.key.code == sf::Keyboard::F4)
				{
					if (mix_value > 0.1f)
					{
						mix_value -= 0.1f;
					}
				}

				// К изначальному
				else if (event.key.code == sf::Keyboard::F10)
				{
					matr = glm::mat4(1.0f);
				}

				// Выбор задания
				else if (event.key.code == sf::Keyboard::Num1)
				{
					shapetype = ShapeType::Cube_task2;
				}
				else if (event.key.code == sf::Keyboard::Num2)
				{
					shapetype = ShapeType::Cube_task3;
				}

			}
		}

		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		Draw(window);
		window.display();
	}
}

void InitVBO()
{
	glGenBuffers(1, &VBO);
	Vertex data[] =
	{
		{0.0f, 0.0f, 0.0f, red, 1.0f, 0.0f}, {0.0f, 1.0f, 1.0f, green, 1.0f, 0.0f}, {1.0f, 0.0f, 1.0f, blue, 1.0f, 0.0f},
		{0.0f, 0.0f, 0.0f, red, 1.0f, 0.0f}, {0.0f, 1.0f, 1.0f, green, 1.0f, 0.0f}, {1.0f, 1.0f, 0.0f, white, 1.0f, 0.0f},
		{0.0f, 0.0f, 0.0f, red, 1.0f, 0.0f}, {1.0f, 1.0f, 0.0f, white, 1.0f, 0.0f}, {1.0f, 0.0f, 1.0f, blue, 1.0f, 0.0f},
		{1.0f, 1.0f, 0.0f, white, 1.0f, 0.0f}, {1.0f, 0.0f, 1.0f, blue, 1.0f, 0.0f}, {0.0f, 1.0f, 1.0f, green, 1.0f, 0.0f},
		{1.0f, 1.0f, -1.0f, red, 1.0f, 0.0f}, {-1.0f, 1.0f, -1.0f, blue, 0.0f, 0.0f}, {-1.0f, 1.0f, 1.0f, green, 0.0f, 1.0f},
		{1.0f, 1.0f, 1.0f, white, 1.0f, 1.0f},	{1.0f, -1.0f, 1.0f, blue, 1.0f, 0.0f}, {-1.0f, -1.0f, 1.0f, red, 0.0f, 0.0f}, 
		{-1.0f, -1.0f, -1.0f, white, 0.0f, 1.0f}, {1.0f, -1.0f, -1.0f, green, 1.0f,1.0f}, {1.0f, 1.0f, 1.0f, white, 1.0f, 0.0f}, 
		{-1.0f, 1.0f, 1.0f, green, 0.0f, 0.0f}, {-1.0f, -1.0f, 1.0f, red, 0.0f, 1.0f}, {1.0f, -1.0f, 1.0f, blue, 1.0f, 1.0f}, 
		{1.0f, -1.0f, -1.0f, green, 0.0f, 1.0f}, {-1.0f, -1.0f, -1.0f, white, 1.0f, 1.0f}, {-1.0f, 1.0f, -1.0f, blue, 1.0f, 0.0f},
		{1.0f, 1.0f, -1.0f, red, 0.0f, 0.0f}, {-1.0f, 1.0f, 1.0f, green, 1.0f, 0.0f}, {-1.0f, 1.0f, -1.0f, blue, 0.0f, 0.0f},
		{-1.0f, -1.0f, -1.0f, white, 0.0f, 1.0f}, {-1.0f, -1.0f, 1.0f, red, 1.0f, 1.0f}, {1.0f, 1.0f, -1.0f, red, 1.0f, 0.0f},
		{1.0f, 1.0f, 1.0f, white, 0.0f, 0.0f}, {1.0f, -1.0f, 1.0f, green, 0.0f, 1.0f}, {1.0f, -1.0f, -1.0f, blue, 1.0f, 1.0f},
	};
	
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(data), data, GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	checkOpenGLerror();
}

void InitTextures()
{
	glGenTextures(1, &texture1);
	glActiveTexture(GL_TEXTURE0);
	glBindTexture(GL_TEXTURE_2D, texture1);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	int width, height, channels;
	unsigned char* data = stbi_load("image.jpg", &width, &height, &channels, 0);
	if (data)
	{
		glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
		glGenerateMipmap(GL_TEXTURE_2D);
	}
	else
	{
		std::cout << "Failed to load texture" << std::endl;
	}
	stbi_image_free(data);

	glGenTextures(1, &texture2);
	glActiveTexture(GL_TEXTURE1);
	glBindTexture(GL_TEXTURE_2D, texture2);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	data = stbi_load("inage.jpg", &width, &height, &channels, 0);
	if (data)
	{
		glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
		glGenerateMipmap(GL_TEXTURE_2D);
	}
	else
	{
		std::cout << "Failed to load texture" << std::endl;
	}
	stbi_image_free(data);
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

	GLuint texVshader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(texVshader, 1, &TexVShader, NULL);
	glCompileShader(texVshader);
	std::cout << "texture vertex shader \n";
	ShaderLog(texVshader);

	GLuint texColFshader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(texColFshader, 1, &TexColorFshader, NULL);
	glCompileShader(texColFshader);
	std::cout << "texture color fragment shader \n";
	ShaderLog(texColFshader);

	GLuint texTexshader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(texTexshader, 1, &TexTextureFshader, NULL);
	glCompileShader(texTexshader);
	std::cout << "texture texture fragment shader \n";
	ShaderLog(texTexshader);

	Task2 = glCreateProgram();
	Task3 = glCreateProgram();

	glAttachShader(Task2, texVshader);
	glAttachShader(Task2, texColFshader);
	glAttachShader(Task3, texVshader);
	glAttachShader(Task3, texTexshader);

	glLinkProgram(Task2);
	glLinkProgram(Task3);

	int link1, link2;
	glGetProgramiv(Task2, GL_LINK_STATUS, &link1);
	glGetProgramiv(Task3, GL_LINK_STATUS, &link2);

	if (!link1 || !link2)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	LoadAttrib(Task2, A2_vertex, "position");
	LoadAttrib(Task2, A2_color, "color");
	LoadAttrib(Task2, A2_texCoord, "texCoord");
	LoadUniform(Task2, A2_affine, "affine");
	LoadUniform(Task2, A2_proj, "proj");
	LoadUniform(Task2, A2_mix_value, "mixValue");

	LoadAttrib(Task3, A3_vertex, "position");
	LoadAttrib(Task3, A3_texCoord, "texCoord");
	LoadUniform(Task3, A3_affine, "affine");
	LoadUniform(Task3, A3_proj, "proj");
	LoadUniform(Task3, A3_mix_value, "mixValue");

	checkOpenGLerror();
}

void Draw(sf::Window& window)
{
	switch (shapetype)
	{
		case ShapeType::Cube_task2:
			window.setTitle("Cube task 2");
			glUseProgram(Task2);
			glUniformMatrix4fv(A2_affine, 1, GL_FALSE, glm::value_ptr(matr));
			glUniformMatrix4fv(A2_proj, 1, GL_FALSE, glm::value_ptr(proj));
			glUniform1f(A2_mix_value, mix_value);
			glUniform1i(glGetUniformLocation(Task2, "Texture"), 0);
			glEnableVertexAttribArray(A2_vertex);
			glEnableVertexAttribArray(A2_color);
			glEnableVertexAttribArray(A2_texCoord);
			glBindBuffer(GL_ARRAY_BUFFER, VBO);
			glVertexAttribPointer(A2_vertex, 3, GL_FLOAT, GL_FALSE, 9 * sizeof(GLfloat), (GLvoid*)0);
			glVertexAttribPointer(A2_color, 4, GL_FLOAT, GL_FALSE, 9 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
			glVertexAttribPointer(A2_texCoord, 2, GL_FLOAT, GL_FALSE, 9 * sizeof(GLfloat), (GLvoid*)(7 * sizeof(GLfloat)));
			glBindBuffer(GL_ARRAY_BUFFER, 0);
			glDrawArrays(GL_QUADS, 12, 24);
			glDisableVertexAttribArray(A2_vertex);
			glDisableVertexAttribArray(A2_color);
			glDisableVertexAttribArray(A2_texCoord);
			glUseProgram(0);
			break;		
		case ShapeType::Cube_task3:
			window.setTitle("Cube task 3");
			glUseProgram(Task3);
			glUniformMatrix4fv(A3_affine, 1, GL_FALSE, glm::value_ptr(matr));
			glUniformMatrix4fv(A3_proj, 1, GL_FALSE, glm::value_ptr(proj));
			glUniform1f(A3_mix_value, mix_value);
			glUniform1i(glGetUniformLocation(Task3, "Texture1"), 0);
			glUniform1i(glGetUniformLocation(Task3, "Texture2"), 1);
			glEnableVertexAttribArray(A3_vertex);
			glEnableVertexAttribArray(A3_texCoord);
			glBindBuffer(GL_ARRAY_BUFFER, VBO);
			glVertexAttribPointer(A3_vertex, 3, GL_FLOAT, GL_FALSE, 9 * sizeof(GLfloat), (GLvoid*)0);
			glVertexAttribPointer(A3_texCoord, 2, GL_FLOAT, GL_FALSE, 9 * sizeof(GLfloat), (GLvoid*)(7 * sizeof(GLfloat)));
			glBindBuffer(GL_ARRAY_BUFFER, 0);
			glDrawArrays(GL_QUADS, 12, 24);
			glDisableVertexAttribArray(A3_vertex);
			glDisableVertexAttribArray(A3_texCoord);
			glUseProgram(0);
			break;
		default:
			break;
	}

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
	glDeleteProgram(Task2);
	glDeleteProgram(Task3);
}