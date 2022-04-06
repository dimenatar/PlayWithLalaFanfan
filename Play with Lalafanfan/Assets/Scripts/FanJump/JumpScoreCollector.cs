using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScoreCollector : Points
{
    [SerializeField] private Transform _duck;

    private void Start()
    {
        _previousPosition = _duck.position;
    }

    private void FixedUpdate()
    {
        CalculateScore();
    }

    protected override void CalculateScore()
    {
        if (_duck.position.y > _previousPosition.y)
        {
            _floatScore += (_duck.position.y - _previousPosition.y) * _addPoints;
            _score = (int)_floatScore;
            OnPointUpdated?.Invoke(_score);
            _previousPosition = _duck.position;
        }
    }
}
