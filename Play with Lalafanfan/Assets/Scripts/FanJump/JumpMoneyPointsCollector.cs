using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMoneyPointsCollector : PointsAndMoneyCollector
{
    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Points.UpdateJumpRecord(_points.Score);
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }
}
