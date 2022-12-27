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

    // ===========
    // Point light
    // ===========
    vec3 lightDir = normalize(pointl.pos - pos); // light direction
    vec3 lightReflDir = reflect(-lightDir, norm2); // reflection direction
    float d = length(lightDir); // distance to light

    float NdotL = max(dot(norm, lightDir), 0); // diffuse shading factor
    float RdotV = max(dot(lightReflDir, viewDir), 0); // specular shading factor

    float atten = 1.0f / (pointl.atten.x + pointl.atten.y * d + pointl.atten.z * d * d);
    vec3 spec = pow(RdotV, material.shininess) * pointl.specular * material.specular;
    vec3 diff = NdotL * material.diffuse * pointl.diffuse;

    vec3 r1 = material.emission;
    r1 += material.ambient * pointl.ambient * atten; // ambient
    r1 += spec * atten; // specular
    r1 += diff * atten; // diffuse


    // =================
    // Directional light
    // =================
    lightDir = normalize(-dirl.direction);
    lightReflDir = reflect(-lightDir, norm2);

    NdotL = max(dot(norm2, lightDir), 0);
    RdotV = max(dot(lightReflDir, viewDir), 0);

    spec = pow(RdotV, material.shininess) * dirl.specular * material.specular;
    diff = NdotL * material.diffuse * dirl.diffuse;
    vec3 r2 = material.emission;
    r2 += material.ambient * dirl.ambient; // ambient
    r2 += spec; // specular
    r2 += diff; // diffuse

    // ==========
    // Spot light
    // ==========
    lightDir = normalize(spotl.pos - pos);
    float theta = dot(lightDir, -normalize(spotl.direction));
    vec3 r3 = vec3(0.0f);

    if(theta > cos(radians(spotl.cutoff))) {
        lightReflDir = reflect(-lightDir, norm2);

        NdotL = max(dot(norm2, lightDir), 0);
        RdotV = max(dot(lightReflDir, viewDir), 0);

        spec = pow(RdotV, material.shininess) * spotl.specular * material.specular;
        diff = NdotL * material.diffuse * spotl.diffuse;
        r3 = material.emission;
        r3 += material.ambient * spotl.ambient; // ambient
        r3 += spec; // specular
        r3 += diff; // diffuse
    }

    vec3 res = r1 + r2 + r3;
    res *= vec3(texture(tex, uv));

    gl_FragColor = vec4(min(res, 1.0f), 1.0f);
}
