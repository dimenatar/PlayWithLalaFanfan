using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsDuck : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _duck;

    void Update()
    {
        if (_duck.position.y > _camera.position.y)
        {
            _camera.position = new Vector3(_camera.position.x, _duck.position.y, _camera.position.z);
        }
    }
}
