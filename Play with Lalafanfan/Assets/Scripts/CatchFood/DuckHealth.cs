using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHealth : MonoBehaviour
{
    [SerializeField] private int _startHealth;

    public delegate void HealthValueChanged(int newValue);
    public event HealthValueChanged OnHealthValueChanged;
    public event Action OnDied;

    private int _health;

    public int Health => _health;
    public int StartHealth => _startHealth;

    public void DecrementHealth()
    {
        _health--;
        OnHealthValueChanged?.Invoke(Health);
        if (Health <= 0)
        {
            OnDied?.Invoke();
        }
    }
}
