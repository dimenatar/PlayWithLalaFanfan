using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyView : MonoBehaviour
{
    [SerializeField] private UserEnergy _userEnergy;
    [SerializeField] private Image _energy;
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        _userEnergy.OnEnergyChanged += ChangeViewValue;
    }

    private void ChangeViewValue(float value)
    {
        if (_userEnergy.MaxEnergy != 0)
        {
            _energy.fillAmount = value / _userEnergy.MaxEnergy;
        }
        else
        {
            _energy.fillAmount = 0;
        }
        _energy.color = _gradient.Evaluate(_energy.fillAmount);
    }
}
