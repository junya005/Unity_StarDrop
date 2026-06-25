using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SelectMenuAnimation : VectorAnimation
{
    public override void Play(Transform menuPanel, Vector3 targetDifferencePos, float duration)
    {
        var children = new Transform[menuPanel.childCount];
        var childIndex = 0;

        foreach (Transform child in menuPanel)
        {
            children[childIndex] = child;
            childIndex++;
        }

        StartCoroutine(StartAnimation(children, targetDifferencePos, duration));
    }

    public IEnumerator StartAnimation(Transform[] children, Vector3 targetDifferencePos, float duration)
    {
        foreach (Transform childTransform in children)
        {
            childTransform.DOMove(childTransform.position + targetDifferencePos, duration);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
