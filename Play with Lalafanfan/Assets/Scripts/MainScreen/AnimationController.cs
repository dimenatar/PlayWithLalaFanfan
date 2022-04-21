using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ShopItemLoader _shopItemLoader;
    [SerializeField] private BackpackItemLoader _backpackItemLoader;
    [SerializeField] private ShopAnimations _shopAnimations;
    [SerializeField] private MainAnimations _mainAnimations;
    [SerializeField] private RoutemapAnimations _routemapAnimations;

    private Stages _currentStage = Stages.Main;

    public void MainClick()
    {
        Animate(_currentStage, Stages.Main);
        _currentStage = Stages.Main;
    }

    public void BackpackClick()
    {
        Animate(_currentStage, Stages.Backpack);
        _currentStage = Stages.Backpack;
    }

    public void RoutmapClick()
    {
        Animate(_currentStage, Stages.Routemap);
        _currentStage = Stages.Routemap;
        //_shopAnimations.ShowFoodShop();
    }

    public void ShopFoodClick()
    {
        Animate(_currentStage, Stages.FoodShop);
        _currentStage = Stages.FoodShop;
    }

    public void WallpapersShopClick()
    {
        Animate(_currentStage, Stages.WallpapersShop);
        _currentStage = Stages.WallpapersShop;
    }

    private void Animate(Stages from, Stages to)
    {
        if (from == to) return;
        Invoke("Show" + to.ToString(), 0);
        Invoke("Hide" + from.ToString(), 0);
    }

    private void LoadBundle(Stages to)
    {

    }

    private void ShowMain() => _mainAnimations.ShowMain();
    private void ShowRoutemap() => _routemapAnimations.ShowRoutemap();
    private void ShowWallpapersShop() => _shopAnimations.ShowWallpapersShop();
    private void ShowFoodShop()
    {
        _shopAnimations.ShowFoodShop();
    }

    private void HideMain() => _mainAnimations.HideMain();
    private void HideRoutemap() => _routemapAnimations.HideRoutemap();
    private void HideFoodShop() => _shopAnimations.HideFoodShop();
    private void HideWallpapersShop() => _shopAnimations.HideWallpaperShop();
}

public enum Stages
{
    Main,
    Routemap,
    Games,
    Backpack,
    FoodShop,
    AppearanceShop,
    WallpapersShop
}
