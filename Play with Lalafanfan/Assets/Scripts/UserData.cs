using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class UserData
{
    private int _highestRunnerPoints;
    private int _money;
    private int _highestStage;

    public int HighestStage => _highestStage;
    public int Money { get => _money; set => _money = value;}
    public int HighestRunnerPoints => _highestRunnerPoints;

    public void CollectData(int money)
    {
        Money = money;
    }

    public void UpdateRunnerRecord(int record)
    {
        if (record > _highestRunnerPoints)
        {
            _highestRunnerPoints = record;
        }
    }

    public void UpdateHighestStage(int stage)
    {
        if (stage > _highestStage)
        {
            _highestStage = stage;
        }
    }
}
