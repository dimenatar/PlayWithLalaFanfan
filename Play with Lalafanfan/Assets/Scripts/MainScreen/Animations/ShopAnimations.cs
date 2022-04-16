using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimations : MonoBehaviour
{
    [SerializeField] private BackgroundImageAnimation _shopBackgroundImage;
    [SerializeField] private BackgroundImageAnimation _shopFoodItems;
    [SerializeField] private GameobjectAnimationBehindScreen _basketAnimations;

    private void Start()
    {

    }

    public void ShowFoodShop()
    {
        _shopBackgroundImage.gameObject.SetActive(true);
        _basketAnimations.gameObject.SetActive(true);
        _shopFoodItems.gameObject.SetActive(true);
        //_basketAnimations.SendObjectsFromScreen();
        _shopFoodItems.AnimateIn();
        _shopBackgroundImage.AnimateIn();
        _basketAnimations.AnimateIn();
    }

    public void HideFoodShop()
    {
        _shopBackgroundImage.AnimateOut();
        _basketAnimations.AnimateOut();
    }

    public void ShowAppearanceShop()
    {

    }

    public void ShowWallpaperShop()
    {

    }
}
