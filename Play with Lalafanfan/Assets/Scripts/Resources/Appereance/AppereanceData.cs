using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AppereanceData : ResourceData, IResource
{
    [SerializeField] private AppearanceType _appereanceType;

    [NonSerialized]
    public static Dictionary<AppearanceType, string> AppearanceTypeTranslate = new Dictionary<AppearanceType, string> { { AppearanceType.Hairstyle, "Прическа"},
        { AppearanceType.Clothes, "Одежда"}, {AppearanceType.Eyecolor, "Цвет глаз"}};

    public AppearanceType Type => _appereanceType;

    public bool IsPurchasableOnFirstClick => throw new NotImplementedException();

    public void PurchaseItem(UserMoney userMoney)
    {
        userMoney.ReduceMoney(Price);
    }
}
