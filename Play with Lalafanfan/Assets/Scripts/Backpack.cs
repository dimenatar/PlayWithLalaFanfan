using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    private Dictionary<FoodData, int> _food;

    public void Initialise(Dictionary <FoodData, int> food)
    {
        _food = food;
    }

    public void AddFood(FoodData foodData)
    {
        if (_food.Keys.Contains(foodData))
        {
            _food[foodData]++;
        }
        else
        {
            _food.Add(foodData, 0);
        }
    }

    public void ReduceFood(FoodData foodData)
    {
        if (_food[foodData] > 0)
        {
            _food[foodData]--;
        }
        else
        {
            _food.Remove(foodData);
        }
    }
}
