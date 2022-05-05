using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField] private SkillType _skillType;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [Range(2, 10)] [SerializeField] private int _order;

    public SkillType SkillType => _skillType;
    public int Price => _price;
    public int Order => _order;
    public string Name => _name;
}
