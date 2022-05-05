using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShop : MonoBehaviour
{
    [SerializeField] private List<SkillUIElement> _elements;
    [SerializeField] private Text _skillName;
    [SerializeField] private Text _skillDescription;
    [SerializeField] private Button _submit;
    [SerializeField] private Color _bought;
    [SerializeField] private Color _buy;

    private UserData _userData;
    private bool _canBuy;
    private Skill _currrentSkill;

    #region const skill Descriptions
    private const string COIN_DESCRIPTION_1 = "Получи";
    private const string COIN_DESCRIPTION_2 = " монет";
    private const string COIN_DESCRIPTION_3 = " за 1 собираемую монету!";

    private const string SATIETY_GROW_DESCRIPTION_1 = "Утка наедается в";
    private const string SATIETY_GROW_DESCRIPTION_2 = " раз";
    private const string SATIETY_GROW_DESCRIPTION_3 = " быстрее";

    private const string ENERGY_GROW_DESCRIPTION_1 = "Утка восстанавливает энергию в";
    private const string ENERGY_GROW_DESCRIPTION_2 = " раз";
    private const string ENERGY_GROW_DESCRIPTION_3 = " быстрее!";

    private const string ENERGY_REDUCE_DESCRIPTION_1 = "Уменьшает траты энергии утки в";
    private const string ENERGY_REDUCE_DESCRIPTION_2 = " раз!";

    private const string BORINGNESS_REDUCE_DESCRIPTION_1 = "Утка заскучает в";
    private const string BORINGNESS_REDUCE_DESCRIPTION_2 = " раз";
    private const string BORINGNESS_REDUCE_DESCRIPTION_3 = "меньше!";
    #endregion

    private void Start()
    {
        _elements.ForEach(element => element.OnSkillClicked += DisplaySkill);
        _userData = UserSaveManager.UserData;
        _submit.onClick.AddListener(Click);
    }

    private void DisplaySkill(Skill skill)
    {
        _currrentSkill = skill;
        _skillName.text = skill.Name;
        _skillDescription.text = GetDescription(skill);
        if (_userData.Skills.HasUserSkill(skill))
        {
            _canBuy = false;
            _submit.GetComponent<Image>().color = _bought;
            _submit.gameObject.transform.Find("Text").GetComponent<Text>().text = "Куплено";
        }
        else
        {
            _canBuy = true;
            _submit.GetComponent<Image>().color = _buy;
            _submit.gameObject.transform.Find("Text").GetComponent<Text>().text = "Купить";
        }
        //todo+    
    }

    private void Click()
    {
        if (_canBuy)
        {
            _userData.Skills.AddSkill(_currrentSkill);
            _submit.GetComponent<Image>().color = _bought;
            _submit.gameObject.transform.Find("Text").GetComponent<Text>().text = "Куплено";
        }
    }

    private string GetDescription(Skill skill)
    {
        switch (skill.SkillType)
        {
            case SkillType.Coins:
                {
                    return skill.Order <= 4 ? COIN_DESCRIPTION_1 + skill.Order + COIN_DESCRIPTION_2 + "ы" + COIN_DESCRIPTION_3 : COIN_DESCRIPTION_1 + skill.Order + COIN_DESCRIPTION_2 + COIN_DESCRIPTION_3;
                }
            case SkillType.Satiety:
                {
                    return skill.Order <= 4 ? SATIETY_GROW_DESCRIPTION_1 + skill.Order + SATIETY_GROW_DESCRIPTION_2 + "а" + SATIETY_GROW_DESCRIPTION_3 : SATIETY_GROW_DESCRIPTION_1 + skill.Order + SATIETY_GROW_DESCRIPTION_2 + SATIETY_GROW_DESCRIPTION_3;
                }
            case SkillType.EnergyBoost:
                {
                    return skill.Order <= 4 ? ENERGY_GROW_DESCRIPTION_1 + skill.Order + ENERGY_GROW_DESCRIPTION_2 + "а" + ENERGY_GROW_DESCRIPTION_3 : ENERGY_GROW_DESCRIPTION_1 + skill.Order + ENERGY_GROW_DESCRIPTION_2 + ENERGY_GROW_DESCRIPTION_3;
                }
            case SkillType.EnergyReduce:
                {
                    return skill.Order <= 4 ? ENERGY_REDUCE_DESCRIPTION_1 + skill.Order + ENERGY_REDUCE_DESCRIPTION_2 + "а" : ENERGY_REDUCE_DESCRIPTION_1 + skill.Order + ENERGY_REDUCE_DESCRIPTION_2;
                }
            case SkillType.BoringnessReduce:
                {
                    return skill.Order <= 4 ? BORINGNESS_REDUCE_DESCRIPTION_1 + skill.Order + BORINGNESS_REDUCE_DESCRIPTION_2 + "а" + BORINGNESS_REDUCE_DESCRIPTION_3 : BORINGNESS_REDUCE_DESCRIPTION_1 + skill.Order + BORINGNESS_REDUCE_DESCRIPTION_2 + BORINGNESS_REDUCE_DESCRIPTION_3;
                }
            default:
                {
                    throw new System.Exception("Not supported action!");
                }
        }

    }
}
