using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDataCollector : MoneyCollector
{
    [SerializeField] private FoodSatiety _userSatiety;
    [SerializeField] private UserEnergy _userEnergy;
    [SerializeField] private UserBoringness _userBoringness;
    [SerializeField] private Backpack _backpack;
    [SerializeField] private SkillsController _skillsController;
    [SerializeField] Wallpapers _wallpapers;
    
    private void Awake()
    {
        //SceneManager.sceneLoaded += LoadMoney;
        //SceneManager.sceneLoaded += LoadIndicators;
        //SceneManager.sceneLoaded += LoadBackpack;
        //SceneManager.sceneLoaded += LoadWallpapers;
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;

        LoadMoney();

    }

    private void Start()
    {
        LoadIndicators();
        LoadWallpapers();
        LoadSkills();
        LoadBackpack();
    }

    private void LoadBackpack()
    {
        _backpack.Initialise(_data.Backpack);
    }

    private void LoadIndicators()
    {
        Debug.Log($"Индикаторы: Энергия{_data.Energy}  Максэнергеия {_data.MaxEnergy}");
        _userSatiety.Initialise(_data.FoodSatiety, _data.MaxFoodSatiety);
        _userEnergy.Initialise(_data.Energy, _data.MaxEnergy);
        _userBoringness.Initialise(_data.Boringness, _data.MaxBoringness);
    }

    private void LoadWallpapers()
    {
        _wallpapers.Initialise(_data.Backpack.CurrentWallpaper, _data.Backpack.Wallpapers);
    }

    private void LoadSkills() => _skillsController.Initialise(_data.Skills);

    protected void LoadMoney()
    {
        _data = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (_data == null)
        {
            Debug.Log(_data);
            _data = new UserData();
            UserSaveManager.SaveUserData(_data);
            UserSaveManager.RewriteUserData();
        }
        Debug.Log($"Data loaded: {_data}");
        _money.SetMoneyAmount(_data.Money);
    }

    protected override void SaveResources(Scene scene)
    {
        SaveResources();
    }

    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Backpack = _backpack.Pack;
        _data.SetIndicators(_userSatiety.Satiety, _userEnergy.Energy, _userBoringness.Boringness);
        _data.SetMaxIndicators(_userSatiety.MaxFoodSatiety, _userEnergy.MaxEnergy, _userBoringness.MaxBoringness);
        Debug.Log($"resources saved! Satiety:{_userSatiety.Satiety},Boringness: {_userBoringness.Boringness},Energy: {_userEnergy.Energy}");
        _data.Backpack.UpdateCurrentWallpaper(_wallpapers.CurrentWallpaper);
        _data.Backpack.Wallpapers = _wallpapers.AvailableWallpapers;
        UserSaveManager.SaveUserData(_data);
        UserSaveManager.RewriteUserData();
    }
}
