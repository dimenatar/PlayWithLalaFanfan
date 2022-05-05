using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private ShopFoodAnimations _shopFoodAnimatations;
    [SerializeField] private WallpaperShopAnimations _wallpaperShopAnimatations;
    [SerializeField] private MainAnimations _mainAnimations;
    [SerializeField] private RoutemapAnimations _routemapAnimations;
    [SerializeField] private BackpackAnimations _backpackAnimations;
    [SerializeField] private BathroomAnimations _bathroomAnimations;

    private bool _isReadyToAnimate = true;
    private IPhaseAnimations currentStage;

    private void Start()
    {
        currentStage = _mainAnimations;
    }

    public void MainClick()
    {
        Animate(currentStage, _mainAnimations);
    }

    public void BackpackClick()
    {
        Animate(currentStage, _backpackAnimations);
    }

    public void RoutmapClick()
    {
        Animate(currentStage, _routemapAnimations);
    }

    public void ShopFoodClick()
    {
        Animate(currentStage, _shopFoodAnimatations);
    }

    public void WallpapersShopClick()
    {
        Animate(currentStage, _wallpaperShopAnimatations);
    }

    public void BathroomClick()
    {
        Animate(currentStage, _bathroomAnimations);
    }

    private void Animate(IPhaseAnimations from, IPhaseAnimations to)
    {
        if (from == to) return;
        if (_isReadyToAnimate)
        {
            _isReadyToAnimate = false;
            if (from is IMainRoomAnimations && from is IDuckAnimations && to is IMainRoomAnimations && to is IDuckAnimations) // тут без разницы что коллить
            {
                Debug.Log("1");
                (from as IMainRoomAnimations).LimitedAnimateOut();
                (to as IMainRoomAnimations).LimitedAnimateIn();
            }
            else if (from is IDuckAnimations && !(from is IMainRoomAnimations) && to is IMainRoomAnimations && to is IDuckAnimations) // если надо заменить только задник, то коллим IDuck
            {
                Debug.Log("2");
                (from as IDuckAnimations).LimitedAnimateOut();
                (to as IDuckAnimations).LimitedAnimateIn();
            }
            else if (to is IDuckAnimations && !(to is IMainRoomAnimations) && from is IMainRoomAnimations && from is IDuckAnimations)
            {
                Debug.Log("3");
                (from as IDuckAnimations).LimitedAnimateOut();
                (to as IDuckAnimations).LimitedAnimateIn();
            }
            else
            {
                from.AnimateOut();
                to.AnimateIn();
            }
            currentStage = to;
            Invoke(nameof(EnableAnimations), 0.5f);
        }
    }

    private void EnableAnimations()
    {
        _isReadyToAnimate = true;
    }
}
