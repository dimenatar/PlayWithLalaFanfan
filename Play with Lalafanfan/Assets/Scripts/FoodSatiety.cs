using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSatiety : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    public delegate void FoodDataUpdated(float amount);

    public event FoodDataUpdated OnFoodSatietyUpdated;
    public event FoodDataUpdated OnMaxFoodSatietyUpdated;

    private float _foodSatiety;
    private float _maxFoodSatiety;

    public float Satiety => _foodSatiety;
    public float MaxFoodSatiety => _maxFoodSatiety;

    public void Initialise(float foodSatiety, float maxFoodSatiety)
    {
        _foodSatiety = foodSatiety;
        _maxFoodSatiety = maxFoodSatiety;

        OnFoodSatietyUpdated?.Invoke(_foodSatiety);
        OnMaxFoodSatietyUpdated?.Invoke(_maxFoodSatiety);
    }

    public bool Feed(float foodAmount)
    {
        if (_foodSatiety != _maxFoodSatiety)
        {
            if (_foodSatiety + foodAmount >= _maxFoodSatiety)
            {
                _foodSatiety = _maxFoodSatiety;
            }
            else
            {
                _foodSatiety += foodAmount;
            }
            OnFoodSatietyUpdated?.Invoke(_foodSatiety);
            return true;
        }
        else
        {
            //OnFoodSatietyUpdated?.Invoke(_foodSatiety);
            return false;
        }
    }

    public void ReduceFoodSatiety(float amount)
    {
        if (_foodSatiety - amount >= 0)
        {
            _foodSatiety -= amount;
        }
        else
        {
            _foodSatiety = 0;
        }
    }

    public void SetMaxFoodSatiety(float maxFoodSatiety)
    {
        _maxFoodSatiety = maxFoodSatiety;
    }
}
