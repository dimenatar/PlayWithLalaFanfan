using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private UserMoney _money;

    public void Add()
    {
        _money.AddMoney(10000);
    }
}
