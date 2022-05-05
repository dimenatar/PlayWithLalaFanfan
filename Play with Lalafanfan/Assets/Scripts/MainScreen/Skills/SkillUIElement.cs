using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillUIElement : MonoBehaviour
{
    [SerializeField] private Skill _skill;

    private Button _button;

    public delegate void SkillClicked(Skill skill);

    public event SkillClicked OnSkillClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(CallEvent);
    }

    public void Initialise(Skill skill)
    {
        _skill = skill;
    }

    private void CallEvent() => OnSkillClicked?.Invoke(_skill);
}
