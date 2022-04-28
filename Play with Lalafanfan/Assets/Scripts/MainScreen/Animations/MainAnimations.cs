using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimations : MonoBehaviour, IMainRoomAnimations, IDuckAnimations
{
    [SerializeField] private GameobjectAnimationBehindScreen _mainRoomAnimation;
    [SerializeField] private GameobjectAnimationBehindScreen _duckAnimation;
    [SerializeField] private GamesAnimations _gamesAnimations;

    private bool _isShowed;

    public bool IsShowed => _isShowed;

    public void AnimateIn()
    {
        _gamesAnimations.gameObject.SetActive(true);
        _duckAnimation.gameObject.SetActive(true);
        _mainRoomAnimation.gameObject.SetActive(true);

        _duckAnimation.AnimateIn();
        _mainRoomAnimation.AnimateIn();
    }

    public void AnimateOut()
    {
        _mainRoomAnimation.AnimateOut();
        _gamesAnimations.AnimateOutWithDisable();
        _duckAnimation.AnimateOut();
    }

    public void LimitedHideMainWithRoom()
    {
        LimitedHideMain();
        _mainRoomAnimation.AnimateOut();
    }


    public void LimitedHideMain()
    {
        _gamesAnimations.AnimateOutWithDisable();
    }

    public void LimitedShowMain()
    {
        _gamesAnimations.gameObject.SetActive(true); 
    }

    public void LimitedShowMainWithDuck()
    {
        LimitedShowMain();
        _duckAnimation.AnimateIn();
    }

    public void LimitedHideMainWithDuck()
    {
        LimitedHideMain();
        _duckAnimation.AnimateOut();
    }

    public void LimitedAnimateIn()
    {
        _gamesAnimations.gameObject.SetActive(true);
    }

    public void LimitedAnimateOut()
    {
        _gamesAnimations.AnimateOutWithDisable();
    }
}
