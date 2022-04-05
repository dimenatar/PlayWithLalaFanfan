using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class UserData
{
    private int _highestRunnerPoints;
    private int _money;
    private float _foodSatiety;
    private float _maxFoodSatiety = 10;
    private UserBackpack _backpack;

    public float FoodSatiety { get => _foodSatiety; set => _foodSatiety = value; }
    public float MaxFoodSatiety => _maxFoodSatiety;
    public int Money { get => _money; set => _money = value;}
    public int HighestRunnerPoints => _highestRunnerPoints;
    public UserBackpack Backpack { get => _backpack; set => _backpack = value; }

    public UserData()
    {
        Backpack = new UserBackpack();
    }

    public void CollectData(int money)
    {
        Money = money;
    }

    public void SetMaxFoodSatiety(float maxFoodSatiety)
    {
        _maxFoodSatiety = maxFoodSatiety;
    }

    public void UpdateRunnerRecord(int record)
    {
        if (record > _highestRunnerPoints)
        {
            _highestRunnerPoints = record;
        }
    }
}
