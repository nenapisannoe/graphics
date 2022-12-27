#version 330 core
in vec3 coord;
in vec2 texcoord;
in vec3 normal;

out vec3 pos;
out vec2 uv;
out vec3 norm;

uniform mat4 mvp;

void main() {
    gl_Position = mvp * vec4(coord, 1.0);
    pos = coord;
	uv = texcoord;
    norm = normal;
}
