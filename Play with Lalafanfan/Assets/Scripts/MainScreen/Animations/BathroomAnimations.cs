using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomAnimations : MonoBehaviour
{
    [SerializeField] private BackgroundImageAnimation _sponge;
    [SerializeField] private GameobjectAnimationBehindScreen _bathroom;
    [SerializeField] private GameobjectAnimationBehindScreen _duck;

    public void AnimateIn()
    {
        LimitedAnimateIn();
        _duck.AnimateIn();
    }

    public void AnimateOut()
    {
        LimitedAnimateOut();
        _duck.AnimateOut();
    }

    public void LimitedAnimateIn()
    {
        _sponge.gameObject.SetActive(true);
        _bathroom.gameObject.SetActive(true);

        _sponge.AnimateIn();
        _bathroom.AnimateIn();
    }

    public void LimitedAnimateOut()
    {
        _sponge.AnimateOut();
        _bathroom.AnimateOut();
    }
}
