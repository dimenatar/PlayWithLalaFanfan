using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public delegate void FoodEmpty(FoodData foodData);
    public event FoodEmpty OnFoodEmpty;

    private UserBackpack _backpack;

    public UserBackpack Pack => _backpack;

    public void Initialise(UserBackpack backpack)
    {
        _backpack = backpack;
        foreach (var item in _backpack.Food)
        {
            Debug.Log(item.Key + "   " + item.Value);
        }
    }

    public void AddFood(FoodData foodData)
    {
        if (_backpack.Food.Where(data => data.Key.Name == foodData.Name).Count() > 0)
        {
            var item = _backpack.Food.FirstOrDefault(data => data.Key.Name == foodData.Name);
            _backpack.Food[item.Key]++;
        }
        else
        {
            _backpack.Food.Add(foodData, 0);
        }
    }

    public int GetFoodItemAmount(FoodData foodData)
    {
        var item = _backpack.Food.FirstOrDefault(data => data.Key.Name == foodData.Name);
        return _backpack.Food[item.Key];
    }

    public void ReduceFood(FoodData foodData)
    {
        var item = _backpack.Food.FirstOrDefault(data => data.Key.Name == foodData.Name);
        if (item.Value > 1)
        {
            _backpack.Food[item.Key]--;
        }
        else
        {
            OnFoodEmpty?.Invoke(item.Key);
            _backpack.Food.Remove(item.Key);
        }
    }
}
