using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ShopItemLoader _shopItemLoader;
    [SerializeField] private BackpackItemLoader _backpackItemLoader;

    private Stages _currentStage = Stages.Main;

    public void GamesClick()
    {
        _currentStage = Stages.Games;
        _animator.SetTrigger("MainToGames");
    }

    public void BackpackClick()
    {
        _currentStage = Stages.Backpack;
        _backpackItemLoader.Initialise();
        _animator.SetTrigger("MainToBackpack");
    }

    public void RoutmapClick()
    {
        _currentStage = Stages.Routemap;
        _animator.SetTrigger("MainToRoute");
    }

    public void ShopFoodClick()
    {
        _currentStage = Stages.ShopFood;
        _shopItemLoader.SwitchToFood();
        _animator.SetTrigger("RouteToBundle");
    }

    public void ReturnClick()
    {
        Debug.Log(_currentStage);
        switch (_currentStage)
        {
            case Stages.Routemap:
                {
                    _currentStage = Stages.Main;
                    _animator.SetTrigger("RouteToMain");
                    break;
                }
            case Stages.Games:
                {
                    _currentStage = Stages.Main;
                    _animator.SetTrigger("GamesToMain");
                    break;
                }
            case Stages.Backpack:
                {
                    _currentStage = Stages.Main;
                    _animator.SetTrigger("BackpackToMain");
                    break;
                }
            case Stages.ShopFood:
                {
                    _currentStage = Stages.Routemap;
                    _animator.SetTrigger("BundleToRoute");
                    break;
                }
            case Stages.ShopAppearance:
                {
                    break;
                }
            case Stages.ShopWallpapers:
                {
                    break;
                }
        }
    }
}

public enum Stages
{
    Main,
    Routemap,
    Games,
    Backpack,
    ShopFood,
    ShopAppearance,
    ShopWallpapers
}
