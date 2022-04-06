using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _duckRigidbody;

    public event Action OnDuckHitsDeadZone;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            OnDuckHitsDeadZone?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void Jump(float force)
    {
        _duckRigidbody.velocity = Vector2.up * force;
    }
}
