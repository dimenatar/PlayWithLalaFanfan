using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundImageAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _animationDurationIn = 0.5f;
    [SerializeField] private float _animationDurationOut = 0.5f;

    private bool _isResized = false;

    public void AnimateIn()
    {
        AnimateToCenter();
    }

    public void AnimateOut()
    {
        AnimateCenterToRight();
    }

    private void Start()
    {

    }

    private void SendPictureFullLeft()
    {
        //Debug.Log(_rectTransform.rect.width);
        _rectTransform.anchoredPosition = new Vector2(-_rectTransform.sizeDelta.x / 2, 0);
    }

    private void AnimateToCenter()
    {
        //_rectTransform.gameObject.SetActive(true);
        if (!_isResized)
        {
            Resize();
            _isResized = true;
        }
        SendPictureFullLeft();
        Debug.Log("animate" + _rectTransform.sizeDelta.x);
        _rectTransform.DOAnchorPos(new Vector2(_rectTransform.sizeDelta.x / 2, _rectTransform.anchoredPosition.y), _animationDurationIn);
    }

    private void AnimateCenterToRight()
    {
        _rectTransform.DOAnchorPos(new Vector2(_rectTransform.sizeDelta.x * 1.5f, _rectTransform.anchoredPosition.y), _animationDurationOut).OnComplete(() => _rectTransform.gameObject.SetActive(false));
    }

    private void Resize()
    {
        _rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        Debug.Log("resize" + _rectTransform.sizeDelta.x / 2);
    }
}
