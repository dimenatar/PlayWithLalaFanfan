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
    [SerializeField] private TextMeshProUGUI _currentExperienceText;
    [SerializeField] private TextMeshProUGUI _experienceToLevelUpText;

    [SerializeField] private Timer _timer;

    [SerializeField] private RectTransform _background;
    [SerializeField] private Image _currentExperience;
    [SerializeField] private Image _instantaneousExperience;

    [SerializeField] private float _fillDelay; // delay to fill experience circle

    private Vector2 _startBackgroundSize;

    private void Awake()
    {
        _timer.OnTime += FillMainCircle;
        _experienceManager.OnCurrentExperienceChanged += UpdateExperience;
        _experienceManager.OnLevelChanged += AnimateBackground;
        _experienceManager.OnLevelChanged += UpdateLevel;
        _experienceManager.OnLevelChanged += ResetCircle;
    }

    private void Start()
    {
        _startBackgroundSize = _background.localScale;
        _timer.Initialise(_fillDelay);
    }

    private void UpdateLevel(Level level)
    {
        _level.text = level.LevelNumber.ToString();
        _experienceToLevelUpText.text = level.ExperienceToLevelUp.ToString();
    }

    private void FillMainCircle()
    {
        _timer.StopTimer();
        _currentExperience.DoFillCircle(_instantaneousExperience.fillAmount, 0.5f);
    }

    private void UpdateExperience(int currentExperience)
    {
        _instantaneousExperience.fillAmount = (float)currentExperience / _experienceManager.CurrentLevel.ExperienceToLevelUp;
        _currentExperienceText.text = currentExperience.ToString();
        if (_timer.IsStarted)
        {
            _timer.UpdateTimer();
        }
        else
        {
            _timer.StartTimer();
        }
        //if (_isReadyToFill)
        //{
        //    _isSavedCurrentExp = false;
        //    _toNextLevel.DoFillCircle(currentExperience / requirableExperience, 0.5f);
        //}
        //else
        //{
        //    if (!_isSavedCurrentExp)
        //    {
        //        _saveCurrentExperience = _toNextLevel.fillAmount;
        //    }
        //    _saveExperienceTo = currentExperience;
        //}
    }

    private void ResetCircle(Level level)
    {
        _currentExperience.DOKill();
        UpdateExperience(_experienceManager.CurrentExperience);
    }

    private void AnimateBackground(Level level)
    {
        _background.DOScale(_background.localScale * 1.5f, 0.1f).OnComplete(() => _background.DOScale(_startBackgroundSize, 1));
    }
}
