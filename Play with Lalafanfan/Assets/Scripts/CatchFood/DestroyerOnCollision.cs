using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<FallingItem>())
        {
            Destroy(collision.gameObject);
        }
    }
}
