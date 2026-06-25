using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFadeAnimation : FadeAnimation
{
    public override void Play(Image image, bool isOut, float duration)
    {
        if (isOut)
        {
            image.DOFade(1.0f, duration);
            return;
        }

        image.DOFade(0.0f, duration);
    }
}
