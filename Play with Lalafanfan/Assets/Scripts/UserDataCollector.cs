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
    [SerializeField] private ExperienceManager _experienceManager;
    [SerializeField] Wallpapers _wallpapers;
    [SerializeField] private StarController _starController;
    [SerializeField] private SkillsView _skillsView;

    private void Awake()
    {
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;

        
        LoadUserData();
    }

    private void Start()
    {
        print("start");
        LoadMoney();
        LoadIndicators();
        LoadWallpapers();
        LoadExperience();
        LoadStars();
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

    protected override void LoadUserData()
    {
        _data = UserSaveManager.UserData;
        _data = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (_data == null)
        {
            Debug.Log("ANAL");
            _data = new UserData();
            UserSaveManager.SaveUserData(_data);
            UserSaveManager.RewriteUserData();
        }
        Debug.Log($"Data loaded: {_data}");
    }

    //protected override void LoadMoney()
    //{
    //    _money.SetMoneyAmount(_data.Money);
    //}

    protected override void SaveResources(Scene scene)
    {
        SaveResources();
    }

    protected override void SaveResources()
    {
        _skillsView.UnsubscribeSkills();

        _data.Money = _money.MoneyAmount;
        _data.Backpack = _backpack.Pack;
        _data.SetIndicators(_userSatiety.Satiety, _userEnergy.Energy, _userBoringness.Boringness);
        _data.SetMaxIndicators(_userSatiety.MaxFoodSatiety, _userEnergy.MaxEnergy, _userBoringness.MaxBoringness);
        Debug.Log($"resources saved! Satiety:{_userSatiety.Satiety},Boringness: {_userBoringness.Boringness},Energy: {_userEnergy.Energy} UserLevel: {_experienceManager.CurrentLevel.LevelNumber}  {_experienceManager.CurrentExperience}");
        _data.Backpack.UpdateCurrentWallpaper(_wallpapers.CurrentWallpaper);
        _data.Backpack.Wallpapers = _wallpapers.AvailableWallpapers;
        _data.CollectExperience(_experienceManager.CurrentLevel, _experienceManager.CurrentExperience);
        _data.CollectStars(_starController.StarCounter);
        UserSaveManager.SaveUserData(_data);
        UserSaveManager.RewriteUserData();
    }

    private void LoadExperience() => _experienceManager.Initialise(_data.CurrentLevel, _data.Experience);
    private void LoadStars() => _starController.Initialise(_data.StarCount);

    private void UpdateValues(Scene scene, LoadSceneMode mode)
    {
        //LoadMoney();
        //LoadExperience();
        //LoadStars();
    }
}
