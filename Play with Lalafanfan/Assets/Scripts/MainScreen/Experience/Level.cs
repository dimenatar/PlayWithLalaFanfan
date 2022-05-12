using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField] [Range(1, 46)] private int _levelNumber = 1;
    [SerializeField] private int _experienceToLevelUp;

    public int LevelNumber => _levelNumber;
    public int ExperienceToLevelUp => _experienceToLevelUp;

    public Level()
    {
        _levelNumber = 1;
        _experienceToLevelUp = 10;
    }
}
