using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMainRoomAnimations : IPhaseAnimations
{
    public void LimitedAnimateIn();
    public void LimitedAnimateOut();
}
