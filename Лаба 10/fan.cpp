// ������ ������ �����������

#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>


// ���������� � ����������������� ID
// ID ��������� ���������
GLuint Program;
// ID ��������
GLint Attrib_vertex;
// ID ������� ���������� �����
GLint Unif_color;
// ID Vertex Buffer Object
GLuint VBO;
// �������
struct Vertex
{
    GLfloat x;
    GLfloat y;
};

float triangle_color[4] = { 0.0f, 0.0f, 1.0f, 1.0f };

// ��������� �������� ���������� �����
void incColor(int index) {
    triangle_color[index] += 0.1;
    if (triangle_color[index] > 1)
        triangle_color[index] = 1;
}

// ��������� �������� ���������� �����
void decColor(int index) {
    triangle_color[index] -= 0.1;
    if (triangle_color[index] < 0)
        triangle_color[index] = 0;
}

// �������� ��� ���������� �������
const char* VertexShaderSource = R"(
    #version 330 core
    in vec2 coord;
    void main() {
        gl_Position = vec4(coord, 0.0, 1.0);
    }
)";


// �������� ��� ������������ �������
const char* FragShaderSource = R"(
    #version 330 core
    out vec4 color;
    void main() {
        color = vec4(1, 0, 0, 1);
    }
)";


// �������� ��� ������������ �������
const char* FragShaderSource2 = R"(
    #version 330 core
    uniform vec4 in_color;
    out vec4 color;
    void main() {
        color = in_color;
    }
)";


void Init();
void Draw();
void Release();


int main() {
    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // ������������� glew
    glewInit();

    Init();

    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                window.close();
            }
            else if (event.type == sf::Event::Resized) {
                glViewport(0, 0, event.size.width, event.size.height);
            }
            // ��������� ������� ������
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                case (sf::Keyboard::Num1): decColor(0); break;
                case (sf::Keyboard::Num2): incColor(0); break;
                default: break;
                }
            }
        }


        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        Draw();

        window.display();
    }

    Release();
    return 0;
}


// �������� ������ OpenGL, ���� ���� �� ����� � ������� ��� ������
void checkOpenGLerror() {
    GLenum errCode;
    // ���� ������ ����� �������� ���
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error!: " << errCode << std::endl;
}

// ������� ������ ���� �������
void ShaderLog(unsigned int shader)
{
    int infologLen = 0;
    int charsWritten = 0;
    char* infoLog;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        infoLog = new char[infologLen];
        if (infoLog == NULL)
        {
            std::cout << "ERROR: Could not allocate InfoLog buffer" << std::endl;
            exit(1);
        }
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog);
        std::cout << "InfoLog: " << infoLog << "\n\n\n";
        delete[] infoLog;
    }
}


void InitVBO()
{
    glGenBuffers(1, &VBO);
    // �������
    Vertex triangle[5] = {
        { 0.0f, -0.4f },
        { -0.7f, 0.2f },
        { -0.3f, 0.4f },
        {0.3f, 0.4f},
        {0.7f, 0.2f}
    };
    // �������� ������� � �����
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    checkOpenGLerror();
}

/*
    float r = 0.5;
	float angle = 3 * PI / 2;
	glGenBuffers(1, &VBO);
	// �������
	Vertex triangle[5];
	for (int i = 0; i < 5; ++i)
	{
		triangle[i] = Vertex{ r * std::cos(angle), r * std::sin(angle) };
		angle += 2 * PI / 5;
	}

    Vertex triangle[4] = {
        { -0.5, -0.5f },
        { 0.5f, -0.5f },
        { 0.5f, 0.5f },
        { -0.5f, 0.5f}
    };
*/


void InitShader() {
    // ������� ��������� ������
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // �������� �������� ���
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // ����������� ������
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    // ������� ����������� ������
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // �������� �������� ���
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    // ����������� ������
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    ShaderLog(fShader);

    // ������� ��������� � ����������� ������� � ���
    Program = glCreateProgram();
    glAttachShader(Program, vShader);
    glAttachShader(Program, fShader);

    // ������� ��������� ���������
    glLinkProgram(Program);
    // ��������� ������ ������
    int link_ok;
    glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
    if (!link_ok)
    {
        std::cout << "error attach shaders \n";
        return;
    }

    // ���������� ID �������� �� ��������� ���������
    const char* attr_name = "coord";
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }

    // ���������� ID �������
    const char* unif_name = "in_color";
    Unif_color = glGetUniformLocation(Program, unif_name);
    if (Unif_color == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }

    checkOpenGLerror();
}

void Init() {
    InitShader();
    InitVBO();
}


void Draw()
{
    // ������������� ��������� ��������� �������
    glUseProgram(Program);
    // �������� ������� � ������
    //glUniform4fv(Unif_color, 1, triangle_color);
    // �������� ������ ���������
    glEnableVertexAttribArray(Attrib_vertex);
    // ���������� VBO
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    // �������� pointer 0 ��� ������������ ������, �� ��������� ��� ������ � VBO
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);
    // ��������� VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    // �������� ������ �� ����������(������)
    glDrawArrays(GL_TRIANGLE_FAN, 0, 5);
    // ��������� ������ ���������
    glDisableVertexAttribArray(Attrib_vertex);
    // ��������� ��������� ���������
    glUseProgram(0);
    checkOpenGLerror();
}


// ������������ ��������
void ReleaseShader() {
    // ��������� ����, �� ��������� �������� ���������
    glUseProgram(0);
    // ������� ��������� ���������
    glDeleteProgram(Program);
}

// ������������ ������
void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO);
}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}
