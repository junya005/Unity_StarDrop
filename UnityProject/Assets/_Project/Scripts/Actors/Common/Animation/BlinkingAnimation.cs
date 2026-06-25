using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingAnimation : MonoBehaviour
{
    private Image _image;
    private SpriteRenderer _spriteRenderer;
    private Tweener tween;

    [SerializeField]
    private float _fadeDuration = 0.2f;

    [SerializeField]
    private float _stopTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Image>(out var imageComponent))
        {
            _image = imageComponent;
            tween = _image.DOFade(0.0f, _fadeDuration).SetLoops(-1, loopType: LoopType.Yoyo).
                                                        OnStepComplete(() =>
                                                        { StartCoroutine(AnimStop(_stopTime)); }
                                                        );
        }

        if (TryGetComponent<SpriteRenderer>(out var spriteRendererComponent))
        {
            _spriteRenderer = spriteRendererComponent;
            tween = _spriteRenderer.DOFade(0.0f, _fadeDuration).SetLoops(-1, loopType: LoopType.Yoyo).
                                                        OnStepComplete(() =>
                                                        { StartCoroutine(AnimStop(_stopTime)); }
                                                        );
        }
    }

    private IEnumerator AnimStop(float stopTime)
    {
        tween.Pause();
        yield return new WaitForSeconds(stopTime);
        tween.Play();
    }
}
