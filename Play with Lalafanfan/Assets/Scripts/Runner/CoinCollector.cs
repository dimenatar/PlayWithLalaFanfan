using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] UserMoney _userMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _userMoney.IncrementMoney();
            Destroy(other.gameObject);
        }
    }
}
