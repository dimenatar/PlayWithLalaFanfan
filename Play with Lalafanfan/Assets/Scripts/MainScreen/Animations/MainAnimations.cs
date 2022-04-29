using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimations : MonoBehaviour, IMainRoomAnimations, IDuckAnimations
{
    [SerializeField] private GameobjectAnimationBehindScreen _mainRoomAnimation;
    [SerializeField] private GameobjectAnimationBehindScreen _duckAnimation;
    [SerializeField] private GamesAnimations _gamesAnimations;

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

    void IMainRoomAnimations.LimitedAnimateIn()
    {
        _gamesAnimations.gameObject.SetActive(true);
    }    

    void IMainRoomAnimations.LimitedAnimateOut()
    {
        _gamesAnimations.AnimateOutWithDisable();
    }

    void IDuckAnimations.LimitedAnimateIn()
    {
        _gamesAnimations.gameObject.SetActive(true);
        _mainRoomAnimation.gameObject.SetActive(true);
        _mainRoomAnimation.AnimateIn();
    }

    void IDuckAnimations.LimitedAnimateOut()
    {
        _gamesAnimations.AnimateOutWithDisable();
        _mainRoomAnimation.AnimateOut();
    }
}
