using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreAndMoneyCollector : MoneyCollector
{
    [SerializeField] private Points _points;

    private int _highestRunnerPoints;

    public int HighestRunnerPoints => _highestRunnerPoints;

    private void Awake()
    {
        SceneManager.sceneLoaded += LoadMoney;
        SceneManager.sceneLoaded += LoadPoints;
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;
    }

    private void LoadPoints(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Points loaded!");
        _highestRunnerPoints = _data.HighestRunnerPoints;
    }

    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.UpdateRunnerRecord(_points.Score);
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }

    protected override void SaveResources(Scene scene)
    {
        SaveResources();
    }
}
