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
        private set
        {
            if (_currentLevel != null)
            {
                if (!_levels.IsLastLevel(_currentLevel))
                {
                    OnCurrentExperienceChanged?.Invoke(value);
                    _currentExperience = value;
                }
            }
        }
    }

    public Level CurrentLevel
    {
       
        get => _currentLevel;
        private set
        {
            _currentLevel = value;
            OnLevelChanged?.Invoke(_currentLevel);
        }
    }

    public void Initialise(Level level, int currentExperience)
    {
        //Debug.Log(level.LevelNumber);
        //Debug.Log(currentExperience);
        CurrentLevel = level;
        CurrentExperience = currentExperience;
    }

    public void AddExperience(int amount)
    {
        if (_levels.IsLastLevel(_currentLevel)) return;
        if (CurrentExperience + amount < CurrentLevel.ExperienceToLevelUp)
        {
            CurrentExperience += amount;
        }
        else
        {
            CurrentExperience += amount - CurrentLevel.ExperienceToLevelUp;
            CurrentLevel = _levels.GetNextLevel(CurrentLevel.LevelNumber);
        }
    }
}
