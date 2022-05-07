using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public static class DOtWeenExtensions
{
    public static Tweener DoFillCircle(this Image self, float endValue, float duration)
    {
        return DOTween.To(() => self.fillAmount, delegate (float x)
        {
            self.fillAmount = x;
        }, endValue, duration).SetTarget(self);
    }
}
