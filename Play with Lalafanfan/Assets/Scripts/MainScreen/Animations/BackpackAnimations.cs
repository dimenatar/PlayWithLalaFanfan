using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackAnimations : MonoBehaviour, IMainRoomAnimations, IDuckAnimations
{
    [SerializeField] private GameobjectAnimationBehindScreen _duck;
    [SerializeField] private GameobjectAnimationBehindScreen _table;
    [SerializeField] private BackgroundImageAnimation _foodItems;
    [SerializeField] private BackpackItemLoader _itemLoader;
    [SerializeField] private GameobjectAnimationBehindScreen _mainRoom;

    public void LimitedAnimateInWithDuck()
    {
        LimitedAnimateIn();
        _duck.AnimateIn();
    }

    public void LimitedAnimateIn()
    {
        _table.gameObject.SetActive(true);
        _foodItems.gameObject.SetActive(true);

        _itemLoader.LoadFood();
        _table.AnimateIn();
        _foodItems.AnimateIn();
    }

    public void AnimateIn()
    {
        _mainRoom.AnimateIn();
        LimitedAnimateInWithDuck();
    }

    public void AnimateOut()
    {
        _mainRoom.AnimateOut();
        LimitedAnimateOut();
    }

    public void LimitedAnimateOut()
    {
        _table.AnimateOut();
        _foodItems.AnimateOut();
    }

}
