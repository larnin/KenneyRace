using UnityEngine;

class CameraMoveEvent
{
    public Vector3 position;
    public Vector3 forward;
    public Vector3 up;
    public Vector3 cameraPosition;
    public Vector3 speed;

    public CameraMoveEvent(Vector3 _position, Vector3 _forward, Vector3 _up, Vector3 _camera, Vector3 _speed)
    {
        position = _position;
        forward = _forward;
        up = _up;
        cameraPosition = _camera;
        speed = _speed;
    }
}

class CameraMoveInstantEvent
{
    public Vector3 position;
    public Vector3 forward;
    public Vector3 up;
    public Vector3 cameraPosition;
    public Vector3 speed;

    public CameraMoveInstantEvent(Vector3 _position, Vector3 _forward, Vector3 _up, Vector3 _camera, Vector3 _speed)
    {
        position = _position;
        forward = _forward;
        up = _up;
        cameraPosition = _camera;
        speed = _speed;
    }
}
