using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallpaperShopAnimations : MonoBehaviour, IMainRoomAnimations, IDuckAnimations
{
    [SerializeField] private BackgroundImageAnimation _wallpapersShopImage;
    [SerializeField] private GameobjectAnimationBehindScreen _roomAnimations;
    [SerializeField] private WallpaperShopManager _wallpaperShopManager;
    [SerializeField] private GameobjectAnimationBehindScreen _duck;

    public void AnimateIn()
    {
        _wallpapersShopImage.gameObject.SetActive(true);
        _roomAnimations.gameObject.SetActive(true);
        _wallpaperShopManager.ShopWallpaperShow();

        _wallpapersShopImage.AnimateIn();
        _roomAnimations.AnimateIn();
    }

    public void AnimateOut()
    {
        (this as IDuckAnimations).AnimateOut();
        _duck.AnimateOut();
    }

    public void LimitedAnimateIn() { throw new System.NotImplementedException("Not supported action!"); }

    void IDuckAnimations.LimitedAnimateOut()
    {
        _wallpapersShopImage.AnimateOut();
        _roomAnimations.AnimateOut();
    }

    void IMainRoomAnimations.LimitedAnimateOut()
    {
        _wallpapersShopImage.AnimateOut();
    }
}
