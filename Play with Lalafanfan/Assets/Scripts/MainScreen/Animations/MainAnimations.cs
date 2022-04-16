using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimations : MonoBehaviour
{
   // [SerializeField] private BackgroundImageAnimation _backgroundImageAnimations;
    [SerializeField] private GameobjectAnimationBehindScreen _mainRoomAnimation;
    [SerializeField] private GameobjectAnimationBehindScreen _duckAnimation;

    public void ShowMain()
    {
        //_backgroundImageAnimations.AnimateIn();
        _duckAnimation.gameObject.SetActive(true);
        _mainRoomAnimation.gameObject.SetActive(true);
        _duckAnimation.AnimateIn();
        _mainRoomAnimation.AnimateIn();
    }

    public void HideMain()
    {
        // _backgroundImageAnimations.AnimateOut();
        //_objectsAnimations.gameObject.SetActive(false);
        _mainRoomAnimation.AnimateOut();
        _duckAnimation.AnimateOut();
    }
}
