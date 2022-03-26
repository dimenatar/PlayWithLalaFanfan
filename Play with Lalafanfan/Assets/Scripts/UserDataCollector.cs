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
        SceneManager.sceneLoaded += LoadBackpack;
        SceneManager.sceneUnloaded += SaveResources;
    }

    private void LoadBackpack(Scene scene, LoadSceneMode mode)
    {
        _backpack.Initialise(_data.Backpack);
    }

    private void LoadFoodData(Scene scene, LoadSceneMode mode)
    {
        _userSatiety.Initialise(_data.FoodSatiety, _data.MaxFoodSatiety);
    }

    protected override void SaveResources(Scene scene)
    {
        _data.Money = _money.MoneyAmount;
        _data.Backpack = _backpack.Pack;
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }
}
