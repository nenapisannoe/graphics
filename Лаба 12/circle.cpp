
// Градиентный треугольник

#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>

GLfloat glfx = 1.0;
GLfloat glfy = -1.0;
// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;
// ID атрибута вершин
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;
// ID юниформ переменной цвета
GLint Unif_color;
// ID VBO вершин
GLuint VBO_position;
// ID VBO цвета
GLuint VBO_color;
// Вершина

struct Vertex
{
    GLfloat x;
    GLfloat y;
};

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
    #version 330 core
    in vec2 coord;
    in vec4 color;

    out vec4 vert_color;

    void main() {
        gl_Position = vec4(coord, 0.0, 1.0);
        vert_color = color;
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core
    in vec4 vert_color;

    out vec4 color;
    void main() {
        color = vert_color;
    }
)";


void Init();
void Draw();
void Release();
void InitVBO();

int main() {
    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // Инициализация glew
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
            }
            else if (event.type == sf::Event::Resized)
            {
                glViewport(0, 0, event.size.width, event.size.height);
            }
            else if (event.type == sf::Event::KeyPressed)
            {
                switch (event.key.code)
                {
                case (sf::Keyboard::Num1):
                    if (glfx < 1)
                        glfx += (GLfloat)0.1; 
                    break;
                case (sf::Keyboard::Num2):
                    if (glfx > 0)
                        glfx -= (GLfloat)0.1; 
                    break;
                case (sf::Keyboard::Num3): 
                    if (glfy < 0)
                        glfy += (GLfloat)0.1; 
                    break;
                case (sf::Keyboard::Num4): 
                    if (glfy > -1)
                        glfy -= (GLfloat)0.1;
                    break;
                default: break;
                }
                InitVBO();
            }
        }

        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        Draw();

        window.display();
    }

    Release();
    return 0;
}


// Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
void checkOpenGLerror()
{
    GLenum errCode;
    // Коды ошибок можно смотреть тут
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error!: " << errCode << std::endl;
}

// Функция печати лога шейдера
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
    glGenBuffers(1, &VBO_position);
    glGenBuffers(1, &VBO_color);
    int triangleAmount = 54;
    GLfloat twicePi = 2.0f * 3.14;
    Vertex triangle[56];
    triangle[0] = { 0,0 };
    for (int i = 0; i <= 54; i++) 
    {
        triangle[i + 1] = { 0 + (glfx * cos(i * twicePi / triangleAmount)),
            0 + (glfy * sin(i * twicePi / triangleAmount)) };
    }
    triangle[55] = { 0 + (glfx * cos(0 * twicePi / triangleAmount)),
           0 + (glfy * sin(0 * twicePi / triangleAmount)) };

    float colors[56][4];
    colors[0][0] = 1;
    colors[0][1] = 1;
    colors[0][2] = 1;
    colors[0][3] = 1;

    int k = 0;
    for (int i = 0; i <= 8; i++)
    {
        colors[i + 1][0] = 1;
        colors[i + 1][1] = 0;
        colors[i + 1][2] = (0.11111111111 * k);
        colors[i + 1][3] = 1;
        k++;
    }

    k = 0;
    for (int i =9; i <=17; i++) 
    {
        colors[i + 1][0] = 1- (0.11111111111 * k);
        colors[i + 1][1] = 0;
        colors[i + 1][2] = 1;
        colors[i + 1][3] = 1;
        k++;
    }

    k = 0;
    for (int i = 18; i <= 26; i++) 
    {
        colors[i + 1][0] = 0;
        colors[i + 1][1] = (0.11111111111 * k);
        colors[i + 1][2] = 1;
        colors[i + 1][3] = 1;
        k++;
    }

    k = 0;
    for (int i = 27; i <= 35; i++) 
    {
        colors[i + 1][0] = 0;
        colors[i + 1][1] = 1;
        colors[i + 1][2] = 1 - (0.11111111111 * k);
        colors[i + 1][3] = 1;
        k++;
    }

    k = 0;
    for (int i = 36; i <= 44; i++) 
    {
        colors[i + 1][0] = (0.11111111111 * k);
        colors[i + 1][1] = 1;
        colors[i + 1][2] = 0;
        colors[i + 1][3] = 1;
        k++;
    }

    k = 0;
    for (int i = 45; i <= 53; i++)
    {
        colors[i + 1][0] = 1;
        colors[i + 1][1] = 1 - (0.11111111111 * k);
        colors[i + 1][2] = 0;
        colors[i + 1][3] = 1;
        k++;
    }
    colors[55][0] = 1;
    colors[55][1] = 0;
    colors[55][2] = 0;
    colors[55][3] = 1;

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors, GL_STATIC_DRAW);
    checkOpenGLerror();
}


/*
Vertex tetrahedron[4] = {
{{ -28.1908 / 55.f, 7.32734 / 55.f - 0.5f, -6.42109 / 55.f }, { green }},
{{ -10.2606 / 55.f, 55.7862 / 55.f - 0.5f, 24.0789 / 55.f }, { blue }},
{{ 28.1908 / 55.f, 10.8908 / 55.f - 0.5f, 13.7884 / 55.f }, { red }},
{{ 10.2606 / 55.f, 45.9957 / 55.f - 0.5f, -31.4461 / 55.f }, { white }},
};
*/



void InitShader()
{
    // Создаем вершинный шейдер
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // Передаем исходный код
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    // Создаем фрагментный шейдер
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // Передаем исходный код
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    ShaderLog(fShader);

    // Создаем программу и прикрепляем шейдеры к ней
    Program = glCreateProgram();
    glAttachShader(Program, vShader);
    glAttachShader(Program, fShader);

    // Линкуем шейдерную программу
    glLinkProgram(Program);
    // Проверяем статус сборки
    int link_ok;
    glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
    if (!link_ok)
    {
        std::cout << "error attach shaders \n";
        return;
    }

    // Вытягиваем ID атрибута вершин из собранной программы
    Attrib_vertex = glGetAttribLocation(Program, "coord");
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib coord" << std::endl;
        return;
    }

    // Вытягиваем ID атрибута цвета
    Attrib_color = glGetAttribLocation(Program, "color");
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib color" << std::endl;
        return;
    }

    checkOpenGLerror();
}

void Init()
{
    InitShader();
    InitVBO();
}

void Draw()
{
    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);
    // Включаем массивы атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);

    // Подключаем VBO_position
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);

    // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_POLYGON, 0, 56);

    // Отключаем массивы атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);

    glUseProgram(0);
    checkOpenGLerror();
}


// Освобождение шейдеров
void ReleaseShader()
{
    // Передавая ноль, мы отключаем шейдрную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(Program);
}

// Освобождение буфера
void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO_position);
    glDeleteBuffers(1, &VBO_color);
}

void Release() 
{
    ReleaseShader();
    ReleaseVBO();
}
