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
        SceneManager.sceneUnloaded += SaveResources;
        Application.quitting += SaveResources;

        LoadUserData();
    }

    private void Start()
    {
        LoadMoney();
        LoadPoints();
    }

    protected void LoadPoints()
    {
        _pointsRecord = _data.Points;
    }

    protected override void SaveResources()
    {
        Debug.LogError("SAVE RESOURCES");
        _data.Money = _money.MoneyAmount;
        _data.Points.UpdateRunnerRecord(_points.Score);
        //UserSaveManager.RewriteUserData(UserSaveManager.Path, _data);
        UserSaveManager.SaveUserData(_data);
    }

    protected override void SaveResources(Scene scene)
    {
        if (scene.name.Equals(SceneManager.GetActiveScene().name))
        {
            SaveResources();
        }
    }
}
