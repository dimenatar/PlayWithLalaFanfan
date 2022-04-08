using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ShopItemLoader _shopItemLoader;
    [SerializeField] private BackpackItemLoader _backpackItemLoader;

    private Stages _currentStage = Stages.Main;

    public void MainClick()
    {
        SetTrigger(_currentStage, Stages.Main);
        _currentStage = Stages.Main;
    }

    public void BackpackClick()
    {
        SetTrigger(_currentStage, Stages.Backpack);
        _currentStage = Stages.Backpack;
    }

    public void RoutmapClick()
    {
        SetTrigger(_currentStage, Stages.Routemap);
        _currentStage = Stages.Routemap;
    }

    public void ShopFoodClick()
    {
        SetTrigger(_currentStage, Stages.ShopFood);
        _currentStage = Stages.ShopFood;
    }

    private void SetTrigger(Stages from, Stages to)
    {
        Debug.Log(from.ToString() + " " + to.ToString());
        if (from == to) return;
        if (to == Stages.Backpack)
        {
            _backpackItemLoader.Initialise();
        }
        if (from == Stages.ShopFood || from == Stages.ShopWallpapers || from == Stages.ShopAppearance)
        {
            _animator.SetTrigger("HideBundle");
            _animator.SetTrigger("Show" + to.ToString());
        }
        else if (to == Stages.ShopFood || to == Stages.ShopWallpapers || to == Stages.ShopAppearance)
        {
            LoadBundle(to);
            _animator.SetTrigger("HideRoutemap");
            _animator.SetTrigger("ShowBundle");
        }
        else
        {
            _animator.SetTrigger("Hide" + from.ToString());
            _animator.SetTrigger("Show" + to.ToString());
        }
    }

    private void LoadBundle(Stages to)
    {
        switch (to)
        {
            case Stages.ShopFood:
                {
                    _shopItemLoader.SwitchToFood();
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
