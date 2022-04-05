using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _duckRigidbody;

    public void Jump(float force)
    {
        _duckRigidbody.velocity = Vector2.up * force;
    }
}
