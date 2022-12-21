#pragma once
const char* VertexShaderSource = R"(
#version 330 core
in vec3 coord;
in vec4 color;
out vec4 vcolor;
uniform mat4 affine;
uniform mat4 proj;
void main() {
    gl_Position = proj * affine * vec4(coord / 2, 1.0);
    vcolor = color;
})";

const char* FragShaderSource = R"(
#version 330 core
in vec4 vcolor;
void main() {
    gl_FragColor = vcolor;
})";

const char* TexVShader = R"(
#version 330 core
in vec3 position;
in vec3 color;
in vec2 texCoord;
out vec3 vcolor;
out vec2 TexCoord;
uniform mat4 affine;
uniform mat4 proj;
void main() {
    gl_Position = proj * affine * vec4(position / 2, 1.0f);
    vcolor = color;
    TexCoord = texCoord;
})";

const char* TexColorFshader = R"(
#version 330 core
in vec3 vcolor;
in vec2 TexCoord;
uniform sampler2D Texture;
uniform float mixValue;
void main() {
     gl_FragColor = mix(texture(Texture, TexCoord), vec4(vcolor, 1.0f), mixValue);
})";

const char* TexTextureFshader = R"(
#version 330 core
in vec3 vcolor;
in vec2 TexCoord;
uniform sampler2D Texture1;
uniform sampler2D Texture2;
uniform float mixValue;
void main() {
    gl_FragColor = mix(texture(Texture1, TexCoord), texture(Texture2, TexCoord), mixValue);
})";