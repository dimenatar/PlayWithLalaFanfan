using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FoodData : ResourceData
{
    [SerializeField] private float _fedForce;
    [SerializeField] private FoodType _foodType;

    public float FedForce => _fedForce;
    public FoodType Type => _foodType;

    public override void AddToBackpack(Backpack backpack)
    {
        backpack.AddFood(this);
    }

    [NonSerialized]
    public static Dictionary<FoodType, string> FoodTypeTranslate = new Dictionary<FoodType, string> { { FoodType.Fruit, "Фрукты"},
        { FoodType.Sweet, "Сладости"}, {FoodType.Vegetable, "Овощи"}, {FoodType.Fastfood, "Фастфуд"}};
}
