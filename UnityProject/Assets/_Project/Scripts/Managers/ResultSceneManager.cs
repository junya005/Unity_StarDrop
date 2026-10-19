using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Project.AudioSystem;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using Unityroom;
using Unityroom.Client;
using System.Text;

public class ResultSceneManager : MonoBehaviour
{
    private const int SCORE_BOARD_ID = 1;

    [SerializeField]
    private Transform _scoreRankImage;

    [SerializeField]
    private SpriteRenderer _scoreRankRenderer;

    [SerializeField]
    private Camera _mainCam;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private TextMeshProUGUI _scoreUploadText;

    [SerializeField]
    private Image _pressAnyImage;

    [SerializeField]
    private string _nextSceneName;

    [SerializeField]
    private List<Sprite> _rankSprite;

    private bool _isCompletedScoreDispAnim;
    private bool _isCompletedScoreUploaded = false;

    // Start is called before the first frame update
    void Start()
    {
        _scoreUploadText.enabled = false;
        SoundManager.Instance.StopBGM();
        StartCoroutine(ResultSequence());
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
        if (Input.anyKeyDown && CheckInputSpetialKeys()
        && _isCompletedScoreDispAnim && _isCompletedScoreUploaded)
        {
            LoadingManager.Instance.ChangeScene(_nextSceneName);
        }

        if (_isCompletedScoreUploaded)
        {
            _scoreUploadText.text = "スコアのアップロード完了!";
        }
        else
        {
            _scoreUploadText.text = "スコアをアップロード中...";
        }
    }

    private IEnumerator ResultSequence()
    {
        yield return ScoreDispAnim();
        var score = ScoreManager.Instance == null ? 0 : ScoreManager.Instance.Score;
        yield return SendGameScore(score);
        _isCompletedScoreUploaded = true;
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

        _scoreUploadText.enabled = true;
        _isCompletedScoreDispAnim = true;
    }

    // スコアを送信する関数
    public async UniTask SendGameScore(float scoreValue)
    {
        UnityroomClient client = new()
        {
            HmacKey = GetSecretKey()
        };

        // 非同期でスコアを送信
        await client.Scoreboards.SendAsync(new()
        {
            ScoreboardId = SCORE_BOARD_ID,
            Score = scoreValue
        });

        Debug.Log("スコアの送信が完了しました！");

        client.Dispose();
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

    private string GetSecretKey()
    {
        byte[] b = new byte[]
        {
            0x30, 0x57, 0x7A, 0x41, 0x78, 0x62, 0x74, 0x4D, 0x5A, 0x50, 0x35, 0x33, 0x59, 0x32, 0x74, 0x55, 0x6D, 0x62, 0x49, 0x6E, 0x46, 0x69, 0x4B, 0x75, 0x6A, 0x64, 0x51, 0x7A, 0x32, 0x35, 0x48, 0x78, 0x42, 0x44, 0x49, 0x48, 0x71, 0x36, 0x57, 0x6A, 0x52, 0x4E, 0x47, 0x30, 0x44, 0x37, 0x58, 0x67, 0x43, 0x65, 0x4A, 0x46, 0x72, 0x76, 0x35, 0x43, 0x7A, 0x44, 0x76, 0x76, 0x56, 0x35, 0x5A, 0x57, 0x46, 0x57, 0x4A, 0x38, 0x30, 0x39, 0x69, 0x61, 0x45, 0x65, 0x73, 0x50, 0x6A, 0x34, 0x46, 0x57, 0x52, 0x68, 0x41, 0x53, 0x55, 0x41, 0x3D, 0x3D,
        };

        return Encoding.UTF8.GetString(b);
    }
}
