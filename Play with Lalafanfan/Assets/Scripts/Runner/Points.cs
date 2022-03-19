using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public delegate void PointUpdated(int value);
    public event PointUpdated OnPointUpdated;

    [SerializeField] private float _addPoints;

    private Vector3 _previousPosition = Vector3.zero;
    private int _score;

    public int Score => _score;

    private void FixedUpdate()
    {
        if (_previousPosition != Vector3.zero)
        {
            float magnitude = (transform.position - _previousPosition).z * _addPoints;
            _score = (int)magnitude;
            OnPointUpdated?.Invoke(_score);
        }
    }
}
