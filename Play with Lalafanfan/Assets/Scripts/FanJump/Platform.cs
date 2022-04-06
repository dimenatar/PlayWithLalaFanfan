using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected float _startJumpForce;

    public delegate void PlatformHitsDeadZone(GameObject platform);
    public event PlatformHitsDeadZone OnHitsDeadZone;

    protected float _jumpMultiplicator = 1;

    public void CalculateJumpMultiplicator()
    {
        _jumpMultiplicator += _jumpMultiplicator /= 15;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<DuckJump>())
        {
            DuckHitsPlatform(collision);
        }
        else if (collision.collider.name == "DeadZone")
        {
            OnHitsDeadZone?.Invoke(gameObject);
        }
    }

    protected virtual void DuckHitsPlatform(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            collision.collider.GetComponent<DuckJump>().Jump(_startJumpForce + _jumpMultiplicator);
        }
    }
}
