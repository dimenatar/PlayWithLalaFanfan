using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PointsRecord
{
    private int _highestRunnerPoints;
    private int _highestJumpPoints;
    private int _highestFoodCatchPoints;

    public int HighestRunnerPoints => _highestRunnerPoints;
    public int HighestJumpPoints => _highestJumpPoints;
    public int HighestFoodCatchPoints => _highestFoodCatchPoints;

    public void UpdateRunnerRecord(int record)
    {
        if (record > _highestRunnerPoints)
        {
            _highestRunnerPoints = record;
        }
    }

    public void UpdateJumpRecord(int record)
    {
        if (record > _highestJumpPoints)
        {
            _highestJumpPoints = record;
        }
    }

    public void UpdateCatchFoodRecord(int record)
    {
        if (record > _highestFoodCatchPoints)
        {
            _highestFoodCatchPoints = record;
        }
    }
}
