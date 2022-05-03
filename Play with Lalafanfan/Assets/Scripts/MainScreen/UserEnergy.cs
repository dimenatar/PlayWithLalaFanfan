using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserEnergy : MonoBehaviour
{
    public delegate void EnergyChanged(float energy);
    public event EnergyChanged OnEnergyChanged;

    private float _energy;
    private float _maxEnergy;

    public void Initialise(float energy, float maxEnergy)
    {
        _maxEnergy = maxEnergy;
        Energy = energy;
    }

    public float Energy 
    {   
        get => _energy; 
        private set
        {
            _energy = value;
            OnEnergyChanged?.Invoke(_energy);
        } 
    }
    public float MaxEnergy => _maxEnergy;

    public void ReduceEnergy(float value)
    {
        if (Energy - value >= 0)
        {
            Energy -= value;
            Debug.Log($"reduce energy by {value}");
        }
        else
        {
            Energy = 0;
        }
    }

    public void AddEnergy(float amount)
    {
        Debug.Log(amount);
        if (Energy + amount <= _maxEnergy)
        {
            Energy += amount;
        }
        else
        {
            Energy = _maxEnergy;
        }
    }
}
