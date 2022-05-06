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

    private void Awake()
    {
        _skillsController.OnInitialised += Initialise;
    }

    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        Debug.Log("1");
        Skills skills = _skillsController.Skills;
        _coins.value = skills.CoinModifier;
        _satiety.value = skills.FoodModifier;
        _energyGrow.value = skills.AddEnergyModifier;
        _energyReduce.value = skills.ReduceEnergyModifier;
        _boringnessReduce.value = skills.BoringnessGrowModifier;
        skills.OnSkillAdded += UpdateValue;
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
