#version 330 core
out vec4 FragColor;

struct Material
{
    sampler2D diffuse;
	sampler2D specular;
    float shininess;
};

struct Light {
    vec3 position;
	vec3  direction;
    float cutOff;
	float outerCutOff;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
	vec3 lightDir = normalize(light.position - FragPos);

	float theta     = dot(lightDir, normalize(-light.direction));
	float epsilon   = light.cutOff - light.outerCutOff;
	float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);   

    
	// 执行光照计算
		vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoords));

		vec3 norm = normalize(Normal);
		

		float diff = max(dot(norm, lightDir), 0.0);
		vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoords));

		float specularStrength = 0.8;
		vec3 viewDir = normalize(viewPos - FragPos);
		vec3 reflectDir = reflect(-lightDir, norm);

		float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
		vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));

		vec3 result = (ambient + diffuse + specular)*intensity;

		FragColor = vec4(result, 1.0);


	
}