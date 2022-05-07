using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExperienceView : MonoBehaviour
{
    [SerializeField] private ExperienceManager _experienceManager;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Image _background;
    [SerializeField] private Image _toNextLevel;

    [SerializeField] private Gradient _gradient;

    private Vector2 _startBackgroundSize;

    private void Awake()
    {
        _experienceManager.OnCurrentExperienceChanged += UpdateExperience;
        _experienceManager.OnLevelChanged += UpdateLevel;
    }

    private void Start()
    {
        _startBackgroundSize = _background.transform.localScale;
    }

    private void UpdateLevel(Level level)
    {
        _level.text = level.LevelNumber.ToString();
    }

    private void UpdateExperience(int currentExperience, int requirableExperience)
    {
        _toNextLevel.DoFillCircle(currentExperience / requirableExperience, 0.5f);
    }
}
