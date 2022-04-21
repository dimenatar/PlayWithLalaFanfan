using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimations : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private float _startXPoint;
    [SerializeField] private float _endXPoint;
    [SerializeField] private RectTransform _element;

    private float _defaultXPoint;

    public void CalculateByCenterPivot()
    {
        _startXPoint = -(Screen.width / 2) - (_element.sizeDelta.x / 2);
        _endXPoint = -_startXPoint;
    }

    public void SendToStartPoint()
    {
        _defaultXPoint = _element.anchoredPosition.x;
        Vector2 elementPosition = _element.anchoredPosition;
        elementPosition.x = _startXPoint - Screen.width;
        _element.anchoredPosition = elementPosition;
    }

    public void AnimateIn()
    {
        SendToStartPoint();
        _element.DOAnchorPos(new Vector2(_defaultXPoint, _element.anchoredPosition.y), _animationDuration);
    }

    public void SendBackToStartPoint()
    {
        _element.DOAnchorPos(new Vector2(_startXPoint, _element.anchoredPosition.y), _animationDuration);
    }

    public void AnimateOut()
    {
        _element.DOAnchorPos(new Vector2(_endXPoint + Screen.width, _element.anchoredPosition.y), _animationDuration).OnComplete(() => _element.gameObject.SetActive(false));
    }
}
