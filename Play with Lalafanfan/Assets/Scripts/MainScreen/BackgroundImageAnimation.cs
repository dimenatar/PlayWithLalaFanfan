using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BackgroundImageAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _animationDurationIn = 0.5f;
    [SerializeField] private float _animationDurationOut = 0.5f;

    public event Action OnAnimationCompleted;

    private bool _isResized = false;
    //private bool _isReadyToAnimate = true;

    public void AnimateIn()
    {
        AnimateToCenter();
    }

    public void AnimateOut()
    {
        AnimateCenterToRight();
    }

    private void SendPictureFullLeft()
    {
        _rectTransform.anchoredPosition = new Vector2(-_rectTransform.sizeDelta.x / 2, 0);
    }

    private void AnimateToCenter()
    {
       // if (_isReadyToAnimate)
        {
          //  _isReadyToAnimate = false;
            //if (!_isResized)
            //{
            //    Resize();
            //    _isResized = true;
            //}
            SendPictureFullLeft();
            _rectTransform.DOAnchorPos(new Vector2(_rectTransform.sizeDelta.x / 2, _rectTransform.anchoredPosition.y), _animationDurationIn).OnComplete(() => OnAnimationIn());
        }
    }

    private void AnimateCenterToRight()
    {
        //if (_isReadyToAnimate)
        {
            //_isReadyToAnimate = false;
            _rectTransform.DOAnchorPos(new Vector2(_rectTransform.sizeDelta.x * 1.5f, _rectTransform.anchoredPosition.y), _animationDurationOut).OnComplete(() => OnAnimateOut(_rectTransform.gameObject));
        }
    }

    private void Resize()
    {
        _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void OnAnimationIn()
    {
        //_isReadyToAnimate = true;
        OnAnimationCompleted?.Invoke();
    }

    private void OnAnimateOut(GameObject item)
    {
       // _isReadyToAnimate = true;
        item.SetActive(false);
        //OnAnimationCompleted?.Invoke();
    }
}
