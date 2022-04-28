using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class GamesAnimations : MonoBehaviour
{
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private float _releasedPosition;
    [SerializeField] private float _startPosition;
    [SerializeField] private RectTransform _element;

    public event Action OnAnimationCompleted;
    private bool _isOpen;

    public void AnimateIn()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            _element.DOAnchorPos(new Vector2(_releasedPosition, 0), _animationDuration);
        }
    }

    public void AnimateOut()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _element.DOAnchorPos(new Vector2(_startPosition, 0), _animationDuration);
        }
    }

    public void AnimateOutWithDisable()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _element.DOAnchorPos(new Vector2(_startPosition, 0), _animationDuration).OnComplete(() => _element.gameObject.SetActive(false));
        }
        else
        {
            _element.gameObject.SetActive(false);
        }
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
}
