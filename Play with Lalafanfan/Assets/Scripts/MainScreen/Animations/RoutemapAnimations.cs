using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutemapAnimations : MonoBehaviour, IPhaseAnimations
{
    [SerializeField] private BackgroundImageAnimation _backgroundImageAnimations;

    public event Action OnAnimationCompleted;

    private void Awake()
    {
        _backgroundImageAnimations.OnAnimationCompleted += () => OnAnimationCompleted?.Invoke();
    }

    public void AnimateIn()
    {
        _backgroundImageAnimations.gameObject.SetActive(true);
        _backgroundImageAnimations.AnimateIn();

    }

    public void AnimateOut()
    {
        _backgroundImageAnimations.AnimateOut();
        //_backgroundImageAnimations.gameObject.SetActive(false);
    }
}
