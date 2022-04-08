using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSatietyView : MonoBehaviour
{
    [SerializeField] private Image _iconSlider;
    [SerializeField] private FoodSatiety _satiety;

    private void Awake()
    {
        _satiety.OnFoodSatietyUpdated += SetSliderValue;
    }

    public void SetSliderValue(float value)
    {
        _iconSlider.fillAmount = value / _satiety.MaxFoodSatiety;
    }
}
