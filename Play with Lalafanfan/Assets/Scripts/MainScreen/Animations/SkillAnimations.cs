using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SkillAnimations : MonoBehaviour
{
    [SerializeField] private RectTransform _element;

    [SerializeField] private Vector2 _startPos;
    [SerializeField] private Vector2 _releasedPos;

    [SerializeField] private float _animationDuration;

    [SerializeField] private Image _button;
    [SerializeField] private Sprite _closedImage;
    [SerializeField] private Sprite _releasedImage;

    private bool _isOpen;
    private bool _isReadyToAnimate;

    public void Animate()
    {
        if (_isReadyToAnimate)
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

    private void AnimateIn()
    {
        _element.DOAnchorPos(_releasedPos, _animationDuration).OnComplete(() => OnAnimateIn());
    }

    private void AnimateOut()
    {
        _element.DOAnchorPos(_startPos, _animationDuration).OnComplete(() => OnAnimateOut());
    }

    private void OnAnimateIn()
    {
        _button.sprite = _releasedImage;
        _isReadyToAnimate = true;
    }

    private void OnAnimateOut()
    {
        _button.sprite = _closedImage;
        _isReadyToAnimate = true;
    }
}
