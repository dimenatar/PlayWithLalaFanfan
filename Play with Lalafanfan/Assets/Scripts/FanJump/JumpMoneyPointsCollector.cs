using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpMoneyPointsCollector : PointsAndMoneyCollector
{
    private void Awake()
    {
        //SceneManager.sceneLoaded += (s, e) => Debug.LogError("JUMP LOADED");
        //SceneManager.sceneLoaded += LoadMoney;
        //SceneManager.sceneLoaded += LoadPoints;
        Debug.Log("JUMP LOADED");
        LoadMoney(new Scene(), LoadSceneMode.Single);
        LoadPoints(new Scene(), LoadSceneMode.Single);
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;
    }

    private void Update()
    {

    }

    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Points.UpdateJumpRecord(_points.Score);
        //UserSaveManager.RewriteUserData(UserSaveManager.Path, _data);
        UserSaveManager.SaveUserData(_data);
    }
}
