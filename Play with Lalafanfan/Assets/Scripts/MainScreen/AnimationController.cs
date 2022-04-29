using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //[SerializeField] private ShopAnimations _shopAnimations;
    [SerializeField] private ShopFoodAnimations _shopFoodAnimatations;
    [SerializeField] private WallpaperShopAnimations _wallpaperShopAnimatations;
    [SerializeField] private MainAnimations _mainAnimations;
    [SerializeField] private RoutemapAnimations _routemapAnimations;
    [SerializeField] private BackpackAnimations _backpackAnimations;
    [SerializeField] private BathroomAnimations _bathroomAnimations;

    public event Action OnAnimationCompleted;

    //private Stages _currentStage = Stages.Main;
    private bool _isReadyToAnimate = true;
    private IPhaseAnimations currentStage;

    private void Start()
    {
        currentStage = _mainAnimations;
    }

    public void MainClick()
    {
        //Animate(_currentStage, Stages.Main);
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

    //private void Animate(Stages from, Stages to)
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
            //else if (!(to is IMainRoomAnimations) && !(to is IDuckAnimations) && from is IMainRoomAnimations && from is IDuckAnimations)
            //{
            //    from.AnimateOut();
            //    to.AnimateIn();
            //}
            //else if ()
            //{

            //}
            else
            {
                from.AnimateOut();
                to.AnimateIn();
            }
            currentStage = to;
            Invoke(nameof(EnableAnimations), 0.5f);
        }
        //
        // if from
        //
        //if (_isReadyToAnimate)
        //{
            //if (from == to) return;
            //_isReadyToAnimate = false;
            //if (from == Stages.Main && to == Stages.Backpack)
            //{
            //    _mainAnimations.LimitedHideMain();
            //    _backpackAnimations.LimitedAnimateIn();
            //}
            //else if (from == Stages.Backpack && to == Stages.Main)
            //{
            //    _backpackAnimations.LimitedHideBackpack();
            //    _mainAnimations.LimitedShowMain();
            //}
            //else if (from == Stages.WallpapersShop && to == Stages.Main)
            //{
            //    _shopAnimations.LimitedHideWallpaperShop();
            //    _mainAnimations.LimitedShowMainWithDuck();
            //}
            //else if (from == Stages.WallpapersShop && to == Stages.Backpack)
            //{
            //    _shopAnimations.LimitedHideWallpaperShop();
            //    _backpackAnimations.LimitedAnimateInWithDuck();
            //}
            //else if (from == Stages.WallpapersShop && to == Stages.Bathroom)
            //{
            //    _shopAnimations.HideWallpaperShop();
            //    _bathroomAnimations.LimitedAnimateIn();
            //}
            //else if (from ==  Stages.Main && to == Stages.Bathroom)
            //{
            //    _mainAnimations.LimitedHideMainWithRoom();
            //    _bathroomAnimations.LimitedAnimateIn();
            //}
            //else if (from == Stages.Backpack && to == Stages.Bathroom)
            //{
            //    _backpackAnimations.LimitedHideBackpackWithRoom();
            //    _bathroomAnimations.LimitedAnimateIn();
            //}
            //else
            //{
            //    Invoke("Show" + to.ToString(), 0);
            //    Invoke("Hide" + from.ToString(), 0);
            //}
            //_currentStage = to;
           // 
        //}
    }

    private void EnableAnimations()
    {
        _isReadyToAnimate = true;
    }
}

//public enum Stages
//{
//    Main,
//    Routemap,
//    Games,
//    Backpack,
//    FoodShop,
//    AppearanceShop,
//    WallpapersShop,
//    Bathroom
//}
