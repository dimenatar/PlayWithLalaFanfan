using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsView : MonoBehaviour
{
    [SerializeField] private SkillsController _skillsController;
    [SerializeField] private Slider _coins;
    [SerializeField] private Slider _satiety;
    [SerializeField] private Slider _energyGrow;
    [SerializeField] private Slider _energyReduce;
    [SerializeField] private Slider _boringnessReduce;

    private Skills _skills;

    private void Awake()
    {
        _skillsController.OnInitialised += Initialise;
    }

    private void Start()
    {
        Initialise();
    }

    public void UnsubscribeSkills()
    {
        _skills.ClearEvent();
    }

    private void Initialise()
    {
        _skills = _skillsController.Skills;
        _coins.value = _skills.CoinModifier;
        _satiety.value = _skills.FoodModifier;
        _energyGrow.value = _skills.AddEnergyModifier;
        _energyReduce.value = _skills.ReduceEnergyModifier;
        _boringnessReduce.value = _skills.BoringnessGrowModifier;
        _skills.OnSkillAdded += UpdateValue;
    }

    private void UpdateValue(Skill skill)
    {
        switch (skill.SkillType)
        {
            case SkillType.Coins:
                {
                    _coins.value = skill.Order;
                    break;
                }
            case SkillType.Satiety:
                {
                    _satiety.value = skill.Order;
                    break;
                }
            case SkillType.EnergyBoost:
                {
                    _energyGrow.value = skill.Order;
                    break;
                }
            case SkillType.EnergyReduce:
                {
                    _energyReduce.value = skill.Order;
                    break;
                }
            case SkillType.BoringnessReduce:
                {
                    _boringnessReduce.value = skill.Order;
                    break;
                }
            default: throw new System.NotImplementedException();
        }

    }
}
