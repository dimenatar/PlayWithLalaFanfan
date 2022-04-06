using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPointsCollector : Points
{
    protected override void CalculateScore()
    {
        if (_previousPosition != Vector3.zero)
        {
            float magnitude = (transform.position - _previousPosition).z * _addPoints;
            _floatScore += magnitude;
            _score = (int)_floatScore;
            OnPointUpdated?.Invoke(_score);
        }
        _previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        CalculateScore();
    }
}
