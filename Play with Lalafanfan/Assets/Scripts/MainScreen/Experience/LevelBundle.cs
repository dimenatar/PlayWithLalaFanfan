using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Bundle", menuName = "Level Bundle", order = 45)]
public class LevelBundle : ScriptableObject
{
    [SerializeField] private List<Level> _levels;

    public List<Level> Levels => _levels;
}
