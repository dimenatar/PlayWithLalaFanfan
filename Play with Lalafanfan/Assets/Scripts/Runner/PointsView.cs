using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PointsView : MonoBehaviour
{
    [SerializeField] private Points _points;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private bool _animate = true;

    private Vector2 _startScale;
    private Vector2 _animatedScale;

    private Tween _tween;

    private void Awake()
    {
        _points.OnPointUpdated += SetPointText;
    }

    private void Start()
    {
        _startScale = _pointsText.transform.localScale;
        _animatedScale = _startScale * 2;
    }

    private void SetPointText(int value)
    {
        if (_animate)
        {
            if (_tween.IsComplete())
            _tween =  _pointsText.transform.DOScale(_pointsText.transform.localScale * 1.2f, 0.1f).OnComplete(() => _pointsText.transform.DOScale(_pointsText.transform.localScale / 1.2f, 0.4f));
        }
        _pointsText.text = value.ToString();
    }
}
