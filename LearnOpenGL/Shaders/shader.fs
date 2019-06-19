#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 TexCoord;

uniform vec3 objectColor;
uniform vec3 lightColor;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float mixv;

void main()
{
	// FragColor = mix(texture(texture1, TexCoord), texture(texture2,  vec2(1-TexCoord.x, TexCoord.y)), mixv);
	FragColor = vec4(lightColor * objectColor, 1.0);
}