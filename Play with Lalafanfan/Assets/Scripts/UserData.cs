using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UserData
{
    public delegate void UserDataInitialised(UserData userData);
    
    public event UserDataInitialised OnUserDataInitialised;

    private int _money;

    private float _foodSatiety = 5;
    private float _boringness = 2;
    private float _energy = 5;

    private float _maxBoringness = 10;
    private float _maxEnergy = 10;
    private float _maxFoodSatiety = 10;

    private UserBackpack _backpack;
    private PointsRecord _points;

    public float FoodSatiety { get => _foodSatiety; private set => _foodSatiety = value; }
    public float Boringness { get => _boringness; private set => _boringness = value; }
    public float Energy { get => _energy; private set => _energy = value; }

    public float MaxFoodSatiety => _maxFoodSatiety;
    public float MaxBoringness => _maxBoringness;
    public float MaxEnergy => _maxEnergy;

    public int Money { get => _money; set => _money = value; }
    public UserBackpack Backpack { get => _backpack; set => _backpack = value; }
    public PointsRecord Points => _points;

    public UserData()
    {
        Backpack = new UserBackpack();
        _points = new PointsRecord();
        OnUserDataInitialised?.Invoke(this);
    }

    public void SetIndicators(float foodSatiety, float energy, float boringness)
    {
        FoodSatiety = foodSatiety;
        Energy = energy;
        Boringness = boringness;
    }

    public void SetMaxIndicators(float maxFoodSatiety, float maxEnergy, float maxBoringness)
    {
        _maxFoodSatiety = maxFoodSatiety;
        _maxEnergy = maxEnergy;
        _maxBoringness = maxBoringness;
    }

    public void CollectData(int money)
    {
        Money = money;
    }

    public void SetMaxFoodSatiety(float maxFoodSatiety)
    {
        _maxFoodSatiety = maxFoodSatiety;
    }
}
