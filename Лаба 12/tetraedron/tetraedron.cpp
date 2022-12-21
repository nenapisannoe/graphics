// Градиентнйы треугольник

#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#include <iostream>


// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;
// ID атрибута вершин
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;

// ID VBO вершин
GLuint VBO_position;
// ID VBO цвета
GLuint VBO_color;
GLuint VBO;
GLint Unif_shift;
// Вершина
struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;
};

float shift[3] = { 0.0f, 0.0f, 0.0f };
// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
    #version 330 core
    in vec3 vertex_pos;
    in vec4 color;
    uniform vec3 shift;
    out vec4 vert_color;
    out vec3 vPosition;
    
    void main() {
        vPosition = vertex_pos;
        float x_angle = 1.1f;
        float y_angle = 1.1f;
        float z_angle = 2.1f;        

        vec3 position = vertex_pos 
        * mat3( cos(-y_angle), 0, -sin(-y_angle),
                0, 1, 0,
                sin(-y_angle), 0, cos(-y_angle) ) 
        * mat3( 1, 0, 0,
                0, cos(x_angle), -sin(x_angle),
                0, sin(x_angle), cos(x_angle) ) 
        * mat3( cos(z_angle), -sin(z_angle), 0,
                sin(z_angle), cos(z_angle), 0,
                0, 0, 1 );
        

        gl_Position = vec4(position, 1.0) *
        mat4( 1, 0, 0, shift[0],
              0, 1, 0, shift[1],
              0, 0, 0, shift[2],
              0, 0, 0, 1 );
        vert_color = color;
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core
    in vec4 vert_color;
    in vec3 vPosition;
    out vec4 color;
    void main() {
        color = vert_color;
    }
)";

void shift_change(float x, float y)
{
    shift[0] += x;
    shift[1] += y;
}

void Init();
void Draw();
void Release();


int main() {
    sf::Window window(sf::VideoMode(800, 800), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // Инициализация glew
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
            // обработка нажатий клавиш
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                case (sf::Keyboard::Right): shift_change(0.01, 0); break;
                case (sf::Keyboard::Left): shift_change(-0.01, 0); break;
                case (sf::Keyboard::Up): shift_change(0, 0.01); break;
                case (sf::Keyboard::Down): shift_change(0, -0.01); break;
                //case (sf::Keyboard::PageUp): shift[2] += 0.01; break;
                //case (sf::Keyboard::PageDown): shift[2] -= 0.01; break;
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


// Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
void checkOpenGLerror() {
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
    glGenBuffers(1, &VBO);
    glGenBuffers(1, &VBO_position);
    glGenBuffers(1, &VBO_color);

    Vertex triangle[12] = 
    {
        {-0.3f,-0.3f,+0.3f }, {-0.3f,+0.2f,-0.1f }, {+0.7f,-0.3f,-0.15f },
        {-0.3f,-0.3f,+0.3f }, {-0.3f,+0.2f,-0.1f}, {-0.3f,-0.1f,-0.6f },
        {-0.3f,-0.1f,-0.6f }, {-0.3f,+0.2f,-0.1f},{+0.7f,-0.3f,-0.15f },
        {-0.3f,-0.3f,+0.3f }, {-0.3f,+0.2f,-0.1f}, {+0.7f,-0.3f,-0.15f }
    };

    // Цвет треугольника
    float colors[12][4] =
    {
        {0.0, 0.0, 1.0, 0.0 }, {1.0, 1.0, 1.0, 1.0 }, {1.0, 0.0, 0.0, 1.0 },
        {0.0, 0.0, 1.0, 0.0 }, {1.0, 1.0, 1.0, 1.0 }, {0.0, 1.0, 0.0, 1.0  },
        {0.0, 1.0, 0.0, 1.0 }, {1.0, 1.0, 1.0, 1.0 }, {1.0, 0.0, 0.0, 1.0 },
        {0.5, 0.5, 0.5, 1.0 }, {0.0, 1.0, 0.0, 1.0 }, {1.0, 0.0, 0.0, 1.0 },
    };

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors, GL_STATIC_DRAW);
    checkOpenGLerror();
}


void InitShader() {
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
    Attrib_vertex = glGetAttribLocation(Program, "vertex_pos");
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib vertex_pos" << std::endl;
        return;
    }

    // Вытягиваем ID атрибута цвета
    Attrib_color = glGetAttribLocation(Program, "color");
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib color" << std::endl;
        return;
    }

    Unif_shift = glGetUniformLocation(Program, "shift");
    if (Unif_shift == -1)
    {
        std::cout << "could not bind uniform shift " << std::endl;
        return;
    }

    checkOpenGLerror();
}

void Init() {
    InitShader();
    InitVBO();
}


void Draw() {
    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);
    // Включаем массивы атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);
    glEnable(GL_DEPTH_TEST);

    // Подключаем VBO_position
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);
    // Подключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, VBO);

    // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);

    glUniform3fv(Unif_shift, 1, shift);

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_TRIANGLES, 0, 12);

    // Отключаем массивы атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);

    glUseProgram(0);
    checkOpenGLerror();
}


// Освобождение шейдеров
void ReleaseShader() {
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

void Release() {
    ReleaseShader();
    ReleaseVBO();
}