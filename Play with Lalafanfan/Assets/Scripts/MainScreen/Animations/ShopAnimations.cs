using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimations : MonoBehaviour
{
    [SerializeField] private BackgroundImageAnimation _shopBackgroundImage;
    [SerializeField] private BackgroundImageAnimation _shopFoodItems;
    [SerializeField] private GameobjectAnimationBehindScreen _basketAnimations;
    [SerializeField] private ShopItemLoader _shopItemLoader;
    [SerializeField] private BackgroundImageAnimation _wallpapersShopImage;
    [SerializeField] private GameobjectAnimationBehindScreen _roomAnimations;
    [SerializeField] private WallpaperShopManager _wallpaperShopManager;

    private void Start()
    {

    }

    public void ShowFoodShop()
    {
        _shopBackgroundImage.gameObject.SetActive(true);
        _basketAnimations.gameObject.SetActive(true);
        _shopFoodItems.gameObject.SetActive(true);
        //_basketAnimations.SendObjectsFromScreen();
        _shopItemLoader.SwitchToFood();
        _shopFoodItems.AnimateIn();
        _shopBackgroundImage.AnimateIn();
        _basketAnimations.AnimateIn();
    }

    public void HideFoodShop()
    {
        _shopBackgroundImage.AnimateOut();
        _shopFoodItems.AnimateOut();
        _basketAnimations.AnimateOut();
    }

    public void ShowAppearanceShop()
    {

    }

    public void ShowWallpapersShop()
    {
        _wallpapersShopImage.gameObject.SetActive(true);
        _roomAnimations.gameObject.SetActive(true);
        _wallpaperShopManager.ShopWallpaperShow();
        
        _wallpapersShopImage.AnimateIn();
        _roomAnimations.AnimateIn();
    }

    public void HideWallpaperShop()
    {
        _wallpapersShopImage.AnimateOut();
        _roomAnimations.AnimateOut();
    }
}
