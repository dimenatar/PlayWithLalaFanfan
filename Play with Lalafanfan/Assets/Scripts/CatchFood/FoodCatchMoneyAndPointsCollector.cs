using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatchMoneyAndPointsCollector : PointsAndMoneyCollector
{
    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Points.UpdateCatchFoodRecord(_points.Score);
        //UserSaveManager.RewriteUserData(UserSaveManager.Path, _data);
        UserSaveManager.SaveUserData(_data);
    }
}
