using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Project.AudioSystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;


public class ResultSceneManager : MonoBehaviour
{
    [SerializeField]
    private Transform _scoreRankImage;

    [SerializeField]
    private SpriteRenderer _scoreRankRenderer;

    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private Image _pressAnyImage;

    [SerializeField]
    private string _nextSceneName;

    [SerializeField]
    private List<Sprite> _rankSprite;

    private bool _isCompletedScoreDispAnim;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.StopBGM();
        StartCoroutine(ScoreDispAnim());
        int score = ScoreManager.Instance.Score;
        _scoreText.text = score.ToString();

        if (score >= 5000)
        {
            _scoreRankRenderer.sprite = _rankSprite[0];
        }
        else if (score >= 2500)
        {
            _scoreRankRenderer.sprite = _rankSprite[1];

        }
        else if (score >= 1250)
        {
            _scoreRankRenderer.sprite = _rankSprite[2];

        }
        else if (score >= 625)
        {
            _scoreRankRenderer.sprite = _rankSprite[3];

        }
        else
        {
            _scoreRankRenderer.sprite = _rankSprite[4];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && CheckInputSpetialKeys())
        {
            if (!_isCompletedScoreDispAnim) return;
            LoadingManager.Instance.ChangeScene(_nextSceneName);
        }
    }

    private IEnumerator ScoreDispAnim()
    {
        _scoreRankImage.DOScale(Vector3.one * 5.0f, 1.0f);
        _scoreRankRenderer.DOFade(1.0f, 1.0f);
        yield return new WaitForSeconds(1.0f + 0.5f);
        _scoreRankImage.DOMove(new Vector3(4.0f, 0.0f, 0.0f), 1.0f);
        _scoreText.DOFade(1.0f, 1.0f);
        _scoreText.transform.DOMove(RectTransformUtility.WorldToScreenPoint(_mainCam, new Vector3(-4.0f, 0.0f, 0.0f)), 1.0f);
        yield return new WaitForSeconds(1.0f);
        _pressAnyImage.gameObject.SetActive(true);

        _isCompletedScoreDispAnim = true;
    }

    private bool CheckInputSpetialKeys()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftWindows) || Input.GetKeyDown(KeyCode.RightWindows))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            return false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
        Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            return false;
        }

        return true;
    }
}
