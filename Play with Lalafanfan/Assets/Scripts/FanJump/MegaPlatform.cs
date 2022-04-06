using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPlatform : Platform
{
    protected override void DuckHitsPlatform(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            collision.collider.GetComponent<DuckJump>().Jump(_startJumpForce + (_jumpMultiplicator * 5));
        }
    }
}
