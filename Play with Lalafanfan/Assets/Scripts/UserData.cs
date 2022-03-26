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

    public float FoodSatiety => _foodSatiety;
    public float MaxFoodSatiety => _maxFoodSatiety;
    public int Money { get => _money; set => _money = value;}
    public int HighestRunnerPoints => _highestRunnerPoints;

    public void CollectData(int money)
    {
        Money = money;
    }

    public void FeedUser(float amount)
    {
        if (_foodSatiety + amount <= _maxFoodSatiety)
        {
            _foodSatiety = _maxFoodSatiety;
        }
        else
        {
            _foodSatiety += amount;
        }
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
