using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public delegate void PointUpdated(int value);
    public PointUpdated OnPointUpdated;

    [SerializeField] protected float _addPoints;

    protected Vector3 _previousPosition = Vector3.zero;
    protected float _floatScore;
    protected int _score;
    public int Score => _score;

    protected virtual void CalculateScore() { }
    protected virtual int GetPoints() => 0;
}
