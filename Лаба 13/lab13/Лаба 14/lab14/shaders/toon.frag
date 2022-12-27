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
uniform vec3 viewPos;

void main()
{
    vec3 viewDir = normalize(viewPos - pos);
    vec3 norm2 = normalize(norm);

    // ==================== Point Light ====================
    vec3 lightDir = normalize(pointl.pos - pos);
    float diff = max(dot(lightDir, norm2), 0.0);
    vec3 r1;
    if (diff < 0.4)
        r1 = vec3(0.3);
    else if (diff < 0.7)
        r1 = vec3(1.0);
    else
        r1 = vec3(1.1);

    // ==================== Directional Light ====================
    vec3 lightDir2 = normalize(dirl.direction);
    float diff2 = max(dot(lightDir2, norm2), 0.0);
    vec3 r2;

    if (diff2 < 0.4)
        r2 = vec3(0.3);
    else if (diff2 < 0.7)
        r2 = vec3(1.0);
    else
        r2 = vec3(1.1);

    // ==================== Spot Light ====================
    vec3 lightDir3 = normalize(spotl.pos - pos);
    float diff3 = max(dot(-lightDir3, norm2), 0.0);
    float theta = dot(lightDir3, -normalize(spotl.direction));
    vec3 r3 = vec3(0.1);
    if (theta > cos(radians(spotl.cutoff))) {
        if (diff3 < 0.4)
            r3 = vec3(0.3);
        else if (diff3 < 0.7)
            r3 = vec3(1.0);
        else
            r3 = vec3(1.1);
    }

    vec3 res = r1 + r2 + r3;
    // res += dirl.ambient * material.ambient + material.emission;
    res *= vec3(texture(tex, uv));
    gl_FragColor = vec4(min(res, 1.0f), 1.0);
}
