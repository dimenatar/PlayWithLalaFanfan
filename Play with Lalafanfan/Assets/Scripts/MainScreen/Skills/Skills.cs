using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Skills
{
    private int _coinModifier = 1;
    private int _foodModifier = 1;
    private int _addEnergyModifier = 1;
    private int _reduceEnergyModifier = 1;
    private float _boringnessGrowModifier = 1;

    private List<Skill> _userSkills;

    public delegate void SkillAdded(Skill skill);

    public event SkillAdded OnSkillAdded;

    public int CoinModifier { get => _coinModifier; set => _coinModifier = value; }
    public int FoodModifier { get => _foodModifier; set => _foodModifier = value; }
    public int AddEnergyModifier { get => _addEnergyModifier; set => _addEnergyModifier = value; }
    public int ReduceEnergyModifier { get => _reduceEnergyModifier; set => _reduceEnergyModifier = value; }
    public float BoringnessGrowModifier { get => _boringnessGrowModifier; set => _boringnessGrowModifier = value; }

    public Skills()
    {
        _userSkills = new List<Skill>();
    }

    public bool HasUserSkill(Skill skill) => _userSkills.Any(s => s.Name.Equals(skill.Name) && s.Order == skill.Order);

    public void AddSkill(Skill skill)
    {
        var existingSkill = _userSkills.Find(s => s.SkillType == skill.SkillType);
        if (existingSkill != null)
        {
            _userSkills.Remove(existingSkill);
        }
        _userSkills.Add(skill);
        OnSkillAdded?.Invoke(skill);
    }

    public bool IsPreviousSkillBought(Skill skill) => _userSkills.Any(s => s.Name.Equals(skill.Name) && skill.Order - 1 == s.Order);
}
