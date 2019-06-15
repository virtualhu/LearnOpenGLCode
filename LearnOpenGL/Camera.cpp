#include "Camera.h"

#include <glm/gtc/matrix_transform.hpp>



Camera::Camera()
	:_view(1.0f),
	pos(0.0f, 0.0f, 3.0f),
	_dir(0.0f, 0.0f, -1.0f),
	_up(0.0f, 1.0f, 0.0f)
{
}


Camera::~Camera()
{
}

glm::mat4 Camera::GetView()
{
	_view = glm::lookAt(pos, pos + _dir, _up);
	return _view;
}
