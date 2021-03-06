using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillShop : MonoBehaviour
{
    [SerializeField] private List<SkillUIElement> _elements;

    [SerializeField] private TextMeshProUGUI _skillName;
    [SerializeField] private TextMeshProUGUI _skillDescription;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _submit;

    [SerializeField] private SkillsController _skillsController;
    [SerializeField] private StarController _starController;

    [SerializeField] private Color _bought;
    [SerializeField] private Color _buy;
    [SerializeField] private Color _gray;

    private bool _canBuy;
    private Skill _currrentSkill;

    #region const skill Descriptions
    private const string COIN_DESCRIPTION_1 = "?????? ";
    private const string COIN_DESCRIPTION_2 = " ?????";
    private const string COIN_DESCRIPTION_3 = " ?? 1 ?????????? ??????!";

    private const string SATIETY_GROW_DESCRIPTION_1 = "???? ????????? ? ";
    private const string SATIETY_GROW_DESCRIPTION_2 = " ???";
    private const string SATIETY_GROW_DESCRIPTION_3 = " ???????";

    private const string ENERGY_GROW_DESCRIPTION_1 = "??????? ???? ?????? ? ";
    private const string ENERGY_GROW_DESCRIPTION_2 = " ???";
    private const string ENERGY_GROW_DESCRIPTION_3 = " ???????!";

    private const string ENERGY_REDUCE_DESCRIPTION_1 = "????????? ????? ??????? ???? ? ";
    private const string ENERGY_REDUCE_DESCRIPTION_2 = " ???";

    private const string BORINGNESS_REDUCE_DESCRIPTION_1 = "???? ????????? ? ";
    private const string BORINGNESS_REDUCE_DESCRIPTION_2 = " ???";
    private const string BORINGNESS_REDUCE_DESCRIPTION_3 = " ????????!";
    #endregion

    #region const button texts
    private const string CAN_BUY = "??????";
    private const string BOUGHT = "???????";
    private const string UNAVAILABLE = "??????????";
    #endregion

    private void Start()
    {
        _elements.ForEach(element => element.OnSkillClicked += DisplaySkill);
        _submit.onClick.AddListener(Click);
    }

    private void DisplaySkill(Skill skill)
    {
        _currrentSkill = skill;
        _skillName.text = skill.Name;
        _skillDescription.text = GetDescription(skill);
        _price.text = skill.Price.ToString();
        if (_skillsController.Skills.HasUserSkill(skill))
        {
            _canBuy = false;
            _submit.GetComponent<Image>().color = _bought;
            _submit.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = BOUGHT;
        }
        else if (_skillsController.Skills.IsPreviousSkillBought(skill) || skill.Order == 2)
        {
            if (_starController.StarCounter >= skill.Price)
            {
                _submit.GetComponent<Image>().color = _buy;
                _canBuy = true;
            }
            else
            {
                _submit.GetComponent<Image>().color = _gray;
                _canBuy = false;
            }
            _submit.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = CAN_BUY;
        }   
        else
        {
            _canBuy = false;
            _submit.GetComponent<Image>().color = _gray;
            _submit.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = UNAVAILABLE;

        }
    }

    private void Click()
    {
        if (_canBuy)
        {
            _skillsController.Skills.AddSkill(_currrentSkill);
            _submit.GetComponent<Image>().color = _bought;
            _submit.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = BOUGHT;
            _starController.SpendStars(_currrentSkill.Price);
        }
    }

    private string GetDescription(Skill skill)
    {
        switch (skill.SkillType)
        {
            case SkillType.Coins:
                {
                    return skill.Order <= 4 ? COIN_DESCRIPTION_1 + skill.Order + COIN_DESCRIPTION_2 + "?" + COIN_DESCRIPTION_3 : COIN_DESCRIPTION_1 + skill.Order + COIN_DESCRIPTION_2 + COIN_DESCRIPTION_3;
                }
            case SkillType.Satiety:
                {
                    return skill.Order <= 4 ? SATIETY_GROW_DESCRIPTION_1 + skill.Order + SATIETY_GROW_DESCRIPTION_2 + "?" + SATIETY_GROW_DESCRIPTION_3 : SATIETY_GROW_DESCRIPTION_1 + skill.Order + SATIETY_GROW_DESCRIPTION_2 + SATIETY_GROW_DESCRIPTION_3;
                }
            case SkillType.EnergyBoost:
                {
                    return skill.Order <= 4 ? ENERGY_GROW_DESCRIPTION_1 + skill.Order + ENERGY_GROW_DESCRIPTION_2 + "?" + ENERGY_GROW_DESCRIPTION_3 : ENERGY_GROW_DESCRIPTION_1 + skill.Order + ENERGY_GROW_DESCRIPTION_2 + ENERGY_GROW_DESCRIPTION_3;
                }
            case SkillType.EnergyReduce:
                {
                    return skill.Order <= 4 ? ENERGY_REDUCE_DESCRIPTION_1 + skill.Order + ENERGY_REDUCE_DESCRIPTION_2 + "?" : ENERGY_REDUCE_DESCRIPTION_1 + skill.Order + ENERGY_REDUCE_DESCRIPTION_2;
                }
            case SkillType.BoringnessReduce:
                {
                    return skill.Order <= 4 ? BORINGNESS_REDUCE_DESCRIPTION_1 + skill.Order + BORINGNESS_REDUCE_DESCRIPTION_2 + "?" + BORINGNESS_REDUCE_DESCRIPTION_3 : BORINGNESS_REDUCE_DESCRIPTION_1 + skill.Order + BORINGNESS_REDUCE_DESCRIPTION_2 + BORINGNESS_REDUCE_DESCRIPTION_3;
                }
            default:
                {
                    throw new System.Exception("Not supported action!");
                }
        }

    }
}
