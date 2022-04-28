using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDuckAnimations : IPhaseAnimations
{
    public void LimitedAnimateIn();
    public void LimitedAnimateOut();
}
