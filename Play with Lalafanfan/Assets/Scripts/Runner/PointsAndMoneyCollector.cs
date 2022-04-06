using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsAndMoneyCollector : MoneyCollector
{
    [SerializeField] protected Points _points;

    protected PointsRecord _pointsRecord;

    public PointsRecord Points => _pointsRecord;

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
        _pointsRecord = _data.Points;
    }

    protected override void SaveResources()
    {
        _data.Money = _money.MoneyAmount;
        _data.Points.UpdateRunnerRecord(_points.Score);
        UserSaveManager.SaveUserData(UserSaveManager.Path, _data);
    }

    protected override void SaveResources(Scene scene)
    {
        SaveResources();
    }
}
