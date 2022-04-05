using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceData : IResource
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private string _iconResourceName;

    public string Name => _name;
    public int Price => _price;
    public string IconResourceName => _iconResourceName;

    public bool IsPurchasableOnFirstClick => throw new NotImplementedException();

    public virtual void AddToBackpack(Backpack backpack)
    {

    }

    public void PurchaseItem(UserMoney userMoney)
    {
        userMoney.ReduceMoney(Price);
    }
}
