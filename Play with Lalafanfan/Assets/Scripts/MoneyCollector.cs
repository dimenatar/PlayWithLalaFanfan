using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] protected UserMoney _money;

    protected UserData _data = null;

    protected virtual void LoadMoney(Scene scene, LoadSceneMode mode)
    {
        //_data = UserSaveManager.LoadUserData(UserSaveManager.Path);
        _data = UserSaveManager.UserData;
        if (_data == null)
        {
            Debug.Log(_data);
            _data = new UserData();
            UserSaveManager.SaveUserData(_data);
            UserSaveManager.RewriteUserData();
        }
        Debug.Log($"Data loaded: {_data} {_data.Points}");
        Debug.LogWarning(_data.Points);
        _money.SetMoneyAmount(_data.Money);
    }

    protected virtual void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        UserSaveManager.SaveUserData(_data);
        //UserSaveManager.RewriteUserData(UserSaveManager.Path, _data);
    }

    protected virtual void SaveResources(Scene scene)
    {
        this.SaveResources();
    }
}
