using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Bundle", menuName = "Level Bundle", order = 45)]
public class LevelBundle : ScriptableObject
{
    [SerializeField] private List<Level> _levels;

    public List<Level> Levels => _levels;

    public Level this[int index]
    {
        get => _levels[index];
    }

    public int this[Level level]
    {
        get => _levels.IndexOf(level);
    }

    public Level GetNextLevel(Level level)
    {
        if (level.LevelNumber != _levels.Count)
        {
            return _levels[_levels.IndexOf(level)+1];
        }
        return null;
    }

    public Level GetNextLevel(int levelNumber)
    {
        if (levelNumber != _levels.Count)
        {
            return _levels[levelNumber];
        }
        return null;
    }

    public bool IsLastLevel(Level level)
    {
        return level.LevelNumber == _levels.Count;
    }
}
