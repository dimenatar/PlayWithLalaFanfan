using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Appearance Bundle", menuName = "Appearance Bundle", order = 42)]
public class AppearanceBundle : ScriptableObject
{
    [SerializeField] private List<AppereanceData> _appearances;

    public List<AppereanceData> Appearances => _appearances;
}
