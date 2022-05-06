using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBoringness : MonoBehaviour
{
    public delegate void BoringnessChanged(float Boringness);

    public event Action OnInitialise;
    public event BoringnessChanged OnBoringnessChanged;

    private float _boringness;
    private float _maxBoringness;

    public float Boringness
    {
        get => _boringness;
        private set
        {
            _boringness = value;
            OnBoringnessChanged?.Invoke(_boringness);
        }
    }
    public float MaxBoringness => _maxBoringness;

    public void Initialise(float boringness, float maxBoringness)
    {
        _maxBoringness = maxBoringness;
        Boringness = boringness;
        OnInitialise?.Invoke();
    }

    public void IncreaseBoringness(float amount)
    {
        if (Boringness + amount <= _maxBoringness)
        {
            Boringness += amount;
        }
        else
        {
            Boringness = _maxBoringness;
        }
    }

    public void ReduceBoringness(float amount)
    {
        if (Boringness - amount >= 0)
        {
            Boringness -= amount;
        }
        else
        {
            Boringness = 0;
        }
    }
}
