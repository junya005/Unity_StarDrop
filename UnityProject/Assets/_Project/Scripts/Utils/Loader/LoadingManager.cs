using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField]
    private Canvas _canvas;
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
        _canvas.gameObject.SetActive(true);
        _loadingPanel.enabled = true;
        _fadeAnimation.Play(_loadingPanel, true, _animDuration);
        yield return new WaitForSeconds(_animDuration);
        yield return SceneManager.LoadSceneAsync(targetScene);
        _fadeAnimation.Play(_loadingPanel, false, _animDuration);
        yield return new WaitForSeconds(_animDuration);
        _loadingPanel.enabled = false;
        _canvas.gameObject.SetActive(false);
    }
}
