using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDataCollector : MoneyCollector
{
    [SerializeField] private FoodSatiety _userSatiety;
    [SerializeField] private Backpack _backpack;
    [SerializeField] Wallpapers _wallpapers;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += LoadMoney;
        SceneManager.sceneLoaded += LoadFoodData;
        SceneManager.sceneLoaded += LoadBackpack;
        SceneManager.sceneLoaded += LoadWallpapers;
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;
    }

    private void LoadBackpack(Scene scene, LoadSceneMode mode)
    {
        _backpack.Initialise(_data.Backpack);
    }

    private void LoadFoodData(Scene scene, LoadSceneMode mode)
    {
        _userSatiety.Initialise(_data.FoodSatiety, _data.MaxFoodSatiety);
    }

    private void LoadWallpapers(Scene scene, LoadSceneMode mode)
    {
        _wallpapers.Initialise(_data.Backpack.CurrentWallpaper, _data.Backpack.Wallpapers);
    }

    protected override void SaveResources(Scene scene)
    {
        SaveResources();
    }

    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Backpack = _backpack.Pack;
        _data.FoodSatiety = _userSatiety.Satiety;
        _data.Backpack.UpdateCurrentWallpaper(_wallpapers.CurrentWallpaper);
        _data.Backpack.Wallpapers = _wallpapers.AvailableWallpapers;
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }
}
