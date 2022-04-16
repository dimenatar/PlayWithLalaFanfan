using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutemapAnimations : MonoBehaviour
{
    [SerializeField] private BackgroundImageAnimation _backgroundImageAnimations;

    public void ShowRoutemap()
    {
        _backgroundImageAnimations.gameObject.SetActive(true);
        _backgroundImageAnimations.AnimateIn();

    }

    public void HideRoutemap()
    {
        _backgroundImageAnimations.AnimateOut();
        //_backgroundImageAnimations.gameObject.SetActive(false);
    }
}
