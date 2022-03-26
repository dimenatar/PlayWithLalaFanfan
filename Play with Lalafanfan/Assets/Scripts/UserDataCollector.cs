using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDataCollector : MoneyCollector
{
    [SerializeField] private FoodSatiety _userSatiety;
    [SerializeField] private Backpack _backpack;

    private void Awake()
    {
        SceneManager.sceneLoaded += LoadMoney;
        SceneManager.sceneLoaded += LoadFoodData;
        SceneManager.sceneUnloaded += SaveResources;
    }

    private void LoadFoodData(Scene scene, LoadSceneMode mode)
    {
        _userSatiety.Initialise(_data.FoodSatiety, _data.MaxFoodSatiety);
    }

    protected override void SaveResources(Scene scene)
    {
        _data.Money = _money.MoneyAmount;
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }
}
