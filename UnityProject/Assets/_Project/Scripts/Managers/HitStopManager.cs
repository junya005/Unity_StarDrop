using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStopManager : Singleton<HitStopManager>
{
    [SerializeField]
    private float _duration = 0.2f;

    private Coroutine _coroutine;

    public void StartHitStop(float duration = 0.0f)
    {
        _coroutine = StartCoroutine(HitStopCoroutine(duration));
    }

    private IEnumerator HitStopCoroutine(float duration)
    {
        if (duration > 0.0f)
        {
            Time.timeScale = 0.0f;
            yield return new WaitForSecondsRealtime(duration);
            Time.timeScale = 1.0f;
            StopCoroutine(_coroutine);
        }

        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(_duration);
        Time.timeScale = 1.0f;
    }
}
