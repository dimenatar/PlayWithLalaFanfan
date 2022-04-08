using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFoodCatcher : MonoBehaviour
{
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private CatchFoodScore _foodScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<FallingItem>())
        {
            if (collision.collider.GetComponent<FallingItem>().Type == Item.Food)
            {
                _foodScore.AddScore();
                Destroy(collision.gameObject);
            }
            else if (collision.collider.GetComponent<FallingItem>().Type == Item.Junk)
            {
                _duckHealth.DecrementHealth();
                Destroy(collision.gameObject);
            }
        }
    }
}
