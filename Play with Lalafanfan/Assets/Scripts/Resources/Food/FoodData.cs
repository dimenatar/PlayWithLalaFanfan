using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FoodData : ResourceData, IResource
{
    [SerializeField] private float _fedForce;
    [SerializeField] private FoodType _foodType;

    public float FedForce => _fedForce;
    public FoodType Type => _foodType;

    public bool IsPurchasableOnFirstClick { get; set; }

    public void PurchaseItem(UserMoney userMoney)
    {
        userMoney.ReduceMoney(Price);
    }

    [NonSerialized]
    public static Dictionary<FoodType, string> FoodTypeTranslate = new Dictionary<FoodType, string> { { FoodType.Fruit, "Фрукты"},
        { FoodType.Sweet, "Сладости"}, {FoodType.Vegetable, "Овощи"}, {FoodType.Fastfood, "Фастфуд"}};
}
