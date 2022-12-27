#pragma once
const char* VertexShaderSource = R"(
#version 330 core
in vec3 coord;
in vec2 uv;
out vec2 texcoord;
flat out int index;
uniform mat4 veiw_point;
uniform vec4 offsets[10];

mat4 rotateX( in float angle ) {
	return mat4(	1.0,		0,			0,			0,
			 		0, 	cos(angle),	-sin(angle),		0,
					0, 	sin(angle),	 cos(angle),		0,
					0, 			0,			  0, 		1);
}

mat4 rotateY( in float angle ) {
	return mat4(	cos(angle),		0,		sin(angle),	0,
			 				0,		1.0,			 0,	0,
					-sin(angle),	0,		cos(angle),	0,
							0, 		0,				0,	1);
}

mat4 rotateZ( in float angle ) {
	return mat4(	cos(angle),		-sin(angle),	0,	0,
			 		sin(angle),		cos(angle),		0,	0,
							0,				0,		1,	0,
							0,				0,		0,	1);
}

void main() {
	float offset = offsets[gl_InstanceID].x;
    float scale = offsets[gl_InstanceID].y;
	float rot_axis = offsets[gl_InstanceID].z;
	float rot_sun = offsets[gl_InstanceID].w;
	vec4 pos = rotateY(rot_axis) * vec4(coord * scale * 2, 1.0);
    pos = rotateY(rot_sun) * (pos + vec4(offset, 0.0, 0.0, 0.0));
    gl_Position = veiw_point * pos;
	texcoord = uv;
	index = gl_InstanceID;
})";

const char* FragShaderSource = R"(
#version 330 core
in vec2 texcoord;
flat in int index;
uniform sampler2D tex[10];

void main() {
	gl_FragColor = texture(tex[index], texcoord);
})";