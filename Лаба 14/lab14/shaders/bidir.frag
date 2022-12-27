#version 330 core
in vec3 pos;
in vec2 uv;
in vec3 norm;

uniform struct PointLight {
    vec3 pos;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    vec3 atten;
} pointl;

uniform struct DirLight {
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
} dirl;

uniform struct SpotLight {
    vec3 pos;
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float cutoff;
    vec3 atten;
} spotl;

uniform struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    vec3 emission;
    float shininess;
} material;

uniform sampler2D tex;
// uniform vec3 viewPos;

void main()
{
    const vec4 col0 = vec4(0.5, 0.0, 0.0, 1.0);
    const vec4 col2 = vec4(0.0, 0.5, 0.0, 1.0);

    // ==================== Point Light ====================
    vec3 lightDir = normalize(pointl.pos - pos);
    vec3 n2 = normalize(norm);

    vec4 r1 = col0 * max(dot(n2, lightDir), 0.0) +
                 col2 * max(dot(n2, -lightDir), 0.0);

    // ==================== Directional Light ====================
    lightDir = normalize(dirl.direction);
    vec4 r2 = col0 * max(dot(n2, lightDir), 0.0) +
                 col2 * max(dot(n2, -lightDir), 0.0);

    // ==================== Spot Light ====================
    lightDir = normalize(spotl.pos - pos);
    float theta = dot(lightDir, -normalize(spotl.direction));
    vec4 r3 = vec4(0.0);
    if (theta > cos(radians(spotl.cutoff))) {
        r3 = col0 * max(dot(n2, lightDir), 0.0) +
                 col2 * max(dot(n2, -lightDir), 0.0);
    }

    vec4 res = r1 + r2 + r3;
    res *= texture(tex, uv);
    gl_FragColor = res;
}
