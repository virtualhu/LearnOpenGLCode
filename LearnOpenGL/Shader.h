#pragma once

#include <glad/glad.h>

#include <string>

class Shader
{
	GLuint ID;
public:
	Shader(const char* vsPath, const char* fsPath);
	~Shader();

	void use();
	void setBool(const std::string& name, bool value) const;
	void setInt(const std::string& name, int value) const;
	void setFloat(const std::string& name, float value)const;
	void setMat4(const std::string& name, const float* value)const;
};

