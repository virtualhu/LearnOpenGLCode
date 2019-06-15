#pragma once

#include <glm/glm.hpp>

class Camera
{
	glm::vec3 _dir;
	glm::vec3 _up;

	glm::mat4 _view;
public:
	Camera();
	~Camera();

	glm::vec3 pos;

	const glm::vec3 GetDir()const { return _dir;  }
	const glm::vec3 GetUp()const { return _up;  }

	void SetDir(glm::vec3 dir) 
	{ 
		_dir = dir;  
	}

	glm::mat4 GetView();
};

