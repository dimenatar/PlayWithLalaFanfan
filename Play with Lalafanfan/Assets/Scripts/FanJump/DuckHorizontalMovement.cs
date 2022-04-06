using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _accelerationX;
    [SerializeField] private Rigidbody2D _duckRigidbody;

    void FixedUpdate()
    {
        _duckRigidbody.velocity = new Vector2(Input.acceleration.x * _accelerationX, _duckRigidbody.velocity.y);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), transform.position.y, transform.position.z);
    }
}
