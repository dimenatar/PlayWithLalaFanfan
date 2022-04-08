using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFoodScore : Points
{
    public void AddScore()
    {
        CalculateScore();
    }

    protected override void CalculateScore()
    {
        _floatScore += _addPoints;
        _score = (int)_floatScore;
        OnPointUpdated?.Invoke(_score);
    }
}
