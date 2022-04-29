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

    public void AnimateIn()
    {
        (this as IDuckAnimations).LimitedAnimateIn();
        _duck.AnimateIn();
    }

    public void AnimateOut()
    {
        (this as IDuckAnimations).LimitedAnimateOut();
        _duck.AnimateOut();
    }

    void IMainRoomAnimations.LimitedAnimateIn()
    {
        _table.gameObject.SetActive(true);
        _foodItems.gameObject.SetActive(true);

        _itemLoader.LoadFood();
        _table.AnimateIn();
        _foodItems.AnimateIn();
    }

    void IMainRoomAnimations.LimitedAnimateOut()
    {
        _table.AnimateOut();
        _foodItems.AnimateOut();
    }

    void IDuckAnimations.LimitedAnimateIn()
    {
        (this as IMainRoomAnimations).LimitedAnimateIn();
        _mainRoom.AnimateIn();
    }

    void IDuckAnimations.LimitedAnimateOut()
    {
        (this as IMainRoomAnimations).LimitedAnimateOut();
        _mainRoom.AnimateOut();
    }
}
