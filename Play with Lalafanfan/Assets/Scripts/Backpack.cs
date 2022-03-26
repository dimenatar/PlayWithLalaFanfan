using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    private UserBackpack _backpack;

    public UserBackpack Pack => _backpack;

    public void Initialise(UserBackpack backpack)
    {
        _backpack = backpack;
    }

    public void AddFood(FoodData foodData)
    {
        if (_backpack.Food.Keys.Contains(foodData))
        {
            _backpack.Food[foodData]++;
        }
        else
        {
            _backpack.Food.Add(foodData, 0);
        }
    }

    public void ReduceFood(FoodData foodData)
    {
        if (_backpack.Food[foodData] > 0)
        {
            _backpack.Food[foodData]--;
        }
        else
        {
            _backpack.Food.Remove(foodData);
        }
    }
}
