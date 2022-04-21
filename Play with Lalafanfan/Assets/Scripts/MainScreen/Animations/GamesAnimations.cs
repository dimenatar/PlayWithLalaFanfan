using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamesAnimations : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private float _startPosLeft = -920.44f;
    [SerializeField] private float _startPosRight = 1055.56f;
    [SerializeField] private RectTransform _element;

    private const float _defaultScreenWidth = 1080;
    private const float _defaultScreenHeight = 2160;
    private const float _leftAnimationRatio = 0.045f;
    private const float _rightAnimationRatio = 0.168214f;

    private float _actualStartPosLeft;
    private float _actualStartPosRight;
    private float _releasedPosLeft;
    private float _releasedPosRight;

    private bool _isCalculated;
    private bool _isOpen;

    public bool IsOpen => _isOpen;

    public void AnimateIn()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            SendToStart();
            _element.DOAnchorPos(new Vector2(_element.anchoredPosition.x + Mathf.Abs(_actualStartPosLeft - _releasedPosLeft), _element.anchoredPosition.y), _animationDuration);
        }
    }

    public void AnimateOut()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _element.DOAnchorPos(new Vector2(_element.anchoredPosition.x - Mathf.Abs(_actualStartPosLeft - _releasedPosLeft), _element.anchoredPosition.y), _animationDuration);
        }
    }

    public void AnimateOutWithDisable()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _element.DOAnchorPos(new Vector2(_element.anchoredPosition.x - Mathf.Abs(_actualStartPosLeft - _releasedPosLeft), _element.anchoredPosition.y), _animationDuration).OnComplete(() => _element.gameObject.SetActive(false));
        }
        else 
        {
            _element.gameObject.SetActive(false);
        }
    }

    public void SendToStart()
    {
        if (!_isCalculated)
        {
            CalculateValues();
        }
        _element.SetLeft(_actualStartPosLeft);
        _element.SetRight(_actualStartPosRight);
    }

    public void ButtonClick()
    {
        if (_isOpen)
        {
            AnimateOut();
        }
        else
        {
            AnimateIn();
        }
    }

    private void CalculateValues()
    {
        _actualStartPosLeft = _startPosLeft - (Screen.width - _defaultScreenWidth);
        _actualStartPosRight = _startPosRight + (Screen.width - _defaultScreenWidth);
        _releasedPosLeft = _actualStartPosLeft * _leftAnimationRatio;
        _releasedPosRight = _actualStartPosRight * _rightAnimationRatio;
        _isCalculated = true;
    }
}
