using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private LevelBundle _levels;

    private int _currentExperience;
    private Level _currentLevel;

    public delegate void CurrentExperienceChanged(int value);
    public delegate void LevelChanged(Level level);

    public event CurrentExperienceChanged OnCurrentExperienceChanged;
    public event LevelChanged OnLevelChanged;

    public int CurrentExperience 
    { 
        get => _currentExperience;
        set
        {
            _currentExperience = value;
            if (_currentLevel != null)
            {
                if (_currentLevel.LevelNumber != 46)
                {
                    //OnCurrentExperienceChanged?.Invoke(value, _levels.Levels[_currentLevel.LevelNumber].ExperienceToLevelUp);
                }
            }
        }
    }

    public Level CurrentLevel
    {
       
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            OnLevelChanged?.Invoke(_currentLevel);
        }
    }

    private void Start()
    {

    }
}
