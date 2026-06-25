using System.Collections;
using System.Collections.Generic;
using Project.AudioSystem;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj;

    [SerializeField]
    private string _nextSceneName;

    private IPlayerHP _playerHP;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(AudioNameConstants.BGM_MAIN_SCENE);
        SoundManager.Instance.SetBgmVolume(0.5f);

        ScoreManager.Instance.ResetScore();

        if (_playerObj.TryGetComponent<Player>(out var component))
            _playerHP = component;

        if (_playerHP != null)
            _playerHP.BindEmptyHPEvent(OnPlayerHpEmpty);
    }

    private void OnPlayerHpEmpty()
    {
        if (_nextSceneName != null)
            LoadingManager.Instance.ChangeScene(_nextSceneName);
    }

}
