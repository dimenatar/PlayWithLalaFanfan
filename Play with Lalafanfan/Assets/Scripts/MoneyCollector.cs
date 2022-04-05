using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] protected UserMoney _money;

    protected UserData _data = null;

    //private void Awake()
    //{
    //    SceneManager.sceneLoaded += LoadMoney;
    //    SceneManager.sceneUnloaded += SaveResources;
    //}

    protected void LoadMoney(Scene scene, LoadSceneMode mode)
    {
        _data = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (_data == null)
        {
            Debug.Log(_data);
            _data = new UserData();
            UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
        }
        Debug.Log(_data.Money + "load");
        _money.SetMoneyAmount(_data.Money);
    }

    protected virtual void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }

    protected virtual void SaveResources(Scene scene)
    {
        this.SaveResources();
    }
}
