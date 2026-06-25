using System.Collections;
using System.Collections.Generic;
using Project.AudioSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplainManager : MonoBehaviour
{
    [SerializeField]
    private string _nextSceneName;

    [SerializeField]
    private ChangeCaption _changeCaption;

    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    [SerializeField]
    private List<CaptionData> _captionDataList = new List<CaptionData>();

    [SerializeField]
    private Image _explainImageSpriteRenderer;

    [SerializeField]
    private List<Sprite> _captionSpriteList;

    private int _currentCaption = 0;

    // Start is called before the first frame update
    void Start()
    {
        _currentCaption = 0;

        string initCaption = _captionDataList[_currentCaption].initCaption;
        string caption = _captionDataList[_currentCaption].caption;
        StartCoroutine(_changeCaption.Display(_textMeshPro, caption, 0.1f, initCaption));

        _currentCaption++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_changeCaption.IsComplete) return;

        if (Input.anyKeyDown)
        {
            SoundManager.Instance.PlaySE(AudioNameConstants.SE_ENTER);

            if (_currentCaption == _captionDataList.Count)
            {
                LoadingManager.Instance.ChangeScene(_nextSceneName);
                return;
            }

            _explainImageSpriteRenderer.sprite = _captionSpriteList[_currentCaption];

            string initCaption = _captionDataList[_currentCaption].initCaption;
            string caption = _captionDataList[_currentCaption].caption;
            StartCoroutine(_changeCaption.Display(_textMeshPro, caption, 0.1f, initCaption));

            _currentCaption++;
        }
    }
}
