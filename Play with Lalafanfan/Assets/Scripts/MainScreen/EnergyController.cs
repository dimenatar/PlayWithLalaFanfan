using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private float _energyPerPlaymodeAmount;
    [SerializeField] private float _energyPerWashingAmount;
    [SerializeField] private UserEnergy _energy;
    [SerializeField] private LevelLoader _levelLoader;

    public void EnterPlaymode(string scene)
    {
        Debug.Log("enter playmode");
        if (_energy.Energy - _energyPerPlaymodeAmount >= 0)
        {
            _energy.ReduceEnergy(_energyPerPlaymodeAmount);
            _levelLoader.LoadLevel(scene);
        }
    }

    public void WashDuck()
    {
        _energy.AddEnergy(_energyPerWashingAmount);
    }
}
