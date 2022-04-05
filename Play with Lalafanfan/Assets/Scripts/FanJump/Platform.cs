using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _startJumpForce;

    public delegate void PlatformHitsDeadZone(GameObject platform);
    public event PlatformHitsDeadZone OnHitsDeadZone;

    private float _jumpMultiplicator = 1;

    public void AddJumpMultiplicator(float force)
    {
        _jumpMultiplicator = force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            if (collision.collider.GetComponent<DuckJump>())
            {
                collision.collider.GetComponent<DuckJump>().Jump(_startJumpForce * _jumpMultiplicator);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DuckJump>())
        {
            other.GetComponent<DuckJump>().Jump(_startJumpForce * _jumpMultiplicator);
        }
    }
}
