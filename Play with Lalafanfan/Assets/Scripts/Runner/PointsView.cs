using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsView : MonoBehaviour
{
    [SerializeField] private Points _points;
    [SerializeField] private Text _pointsText;

    private void Awake()
    {
        _points.OnPointUpdated += SetPointText;
    }

    private void SetPointText(int value)
    {
        _pointsText.text = value.ToString();
    }
}
