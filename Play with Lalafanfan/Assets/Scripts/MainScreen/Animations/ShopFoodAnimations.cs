using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFoodAnimations : MonoBehaviour, IPhaseAnimations
{
    [SerializeField] private BackgroundImageAnimation _shopBackgroundImage;
    [SerializeField] private BackgroundImageAnimation _shopFoodItems;
    [SerializeField] private GameobjectAnimationBehindScreen _basketAnimations;
    [SerializeField] private ShopItemLoader _shopItemLoader;
    [SerializeField] private ShopBasketLoader _shotBasketLoader;

    public void AnimateIn()
    {
        _shotBasketLoader.ClearBasket();
        _shopBackgroundImage.gameObject.SetActive(true);
        _basketAnimations.gameObject.SetActive(true);
        _shopFoodItems.gameObject.SetActive(true);

        _shopItemLoader.SwitchToFood();
        _shopFoodItems.AnimateIn();
        _shopBackgroundImage.AnimateIn();
        _basketAnimations.AnimateIn();
    }

    public void AnimateOut()
    {
        _shopBackgroundImage.AnimateOut();
        _shopFoodItems.AnimateOut();
        _basketAnimations.AnimateOut();
    }
}
