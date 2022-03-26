using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Food Bundle", menuName = "Food Bundle", order = 41)]
public class FoodBundle : ScriptableObject
{
    [SerializeField] private List<FoodData> _foodBuble;
    [SerializeField] private int _categoryAmount;

    public List<FoodData> Foods => _foodBuble;
    public int CategoryAmount => _categoryAmount;
}
