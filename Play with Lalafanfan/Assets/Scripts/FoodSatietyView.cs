using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSatietyView : MonoBehaviour
{
    [SerializeField] private Slider _foodSlider;
    [SerializeField] private FoodSatiety _satiety;

    private void Awake()
    {
        _satiety.OnFoodSatietyUpdated += SetSliderValue;
        _satiety.OnMaxFoodSatietyUpdated += SetSliderMaxValue;
    }

    public void SetSliderValue(float value)
    {
        _foodSlider.value = value;
    }

    public void SetSliderMaxValue(float value)
    {
        _foodSlider.maxValue = value;
    }    
}
