using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField]
    private Image _loadingPanel;
    [SerializeField]
    private FadeAnimation _fadeAnimation;
    [SerializeField]
    private float _animDuration;

    public void ChangeScene(string targetScene)
    {
        StartCoroutine(ChangeSceneAnimation(targetScene));
    }

    public IEnumerator ChangeSceneAnimation(string targetScene)
    {
        _loadingPanel.enabled = true;
        _fadeAnimation.Play(_loadingPanel, true, _animDuration);
        yield return new WaitForSeconds(_animDuration);
        yield return SceneManager.LoadSceneAsync(targetScene);
        _fadeAnimation.Play(_loadingPanel, false, _animDuration);
        yield return new WaitForSeconds(_animDuration);
        _loadingPanel.enabled = false;
    }
}
