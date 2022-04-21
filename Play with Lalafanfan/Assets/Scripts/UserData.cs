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
    private float _foodSatiety;
    private float _maxFoodSatiety = 10;
    private UserBackpack _backpack;
    private PointsRecord _points;

    public float FoodSatiety { get => _foodSatiety; set => _foodSatiety = value; }
    public float MaxFoodSatiety => _maxFoodSatiety;
    public int Money { get => _money; set => _money = value; }
    public UserBackpack Backpack { get => _backpack; set => _backpack = value; }
    public PointsRecord Points => _points;

    public UserData()
    {
        Debug.Log(Backpack);
        Backpack = new UserBackpack();
        Debug.Log(Backpack);
        _points = new PointsRecord();
        OnUserDataInitialised?.Invoke(this);
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
