using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WallpaperData : ResourceData, IResource
{
    public bool IsPurchasableOnFirstClick => throw new System.NotImplementedException();

    public void PurchaseItem(UserMoney userMoney)
    {
        userMoney.ReduceMoney(Price);
    }
}
