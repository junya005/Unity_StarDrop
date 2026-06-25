using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>メニュー選択を統括するクラス</summary>
public class SelectMenuManager : MonoBehaviour
{
    [Header("オブジェクト参照")]
    [SerializeField, Tooltip("モード選択パネルを設定")]
    private Transform _modePanel = null;

    [SerializeField, Tooltip("設定パネルを設定")]
    private Transform _settingPanel = null;

    [SerializeField, Tooltip("難易度選択パネルを設定")]
    private Transform _difficultyPanel = null;

    [SerializeField, Tooltip("アニメーションクラスを設定")]
    private VectorAnimation _animationClass = null;

    [Header("パラメーター")]
    [SerializeField, Tooltip("アニメーション移動値")]
    private Vector3 _animMoveValue = new Vector3(0, 0, 0);

    [SerializeField, Tooltip("アニメーション秒数")]
    private float _animDuration = 1.0f;

    private ESelectFlowState _currentSelectFlowState = ESelectFlowState.Mode;
    private ESelectFlowState _previousSelectFlowState = ESelectFlowState.Mode;
    private bool _canChangeMenu = true;

    // Start is called before the first frame update
    void Start()
    {
        _canChangeMenu = true;
        _animMoveValue = new Vector3(0, -Screen.height, 0);
        _settingPanel.gameObject.SetActive(false);
        _difficultyPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 前のメニューに戻る
        if (Input.GetKeyDown(KeyCode.Escape))
            BackMenu();
    }

    /// <summary>
    /// ボタンのバインド用
    /// </summary>
    /// <param name="stateIndex">ESelectFlowStateを番号で指定</param>
    public void OnClick(int stateIndex)
    {
        int enumLength = Enum.GetNames(typeof(ESelectFlowState)).Length;

        if (stateIndex >= enumLength || stateIndex < 0)
        {
            Debug.Log("値が範囲外につき無効です。");
            return;
        }

        ChangeMenu((ESelectFlowState)stateIndex);
    }

    /// <summary>
    /// メニューを切り替える
    /// </summary>
    /// <param name="targetState">移動先のメニュー</param>
    public void ChangeMenu(ESelectFlowState targetState)
    {
        if (!_canChangeMenu) return;

        // 現在ステートから現在画面のパネルを取得
        Transform currentPanel = GetPanel(_currentSelectFlowState);

        // 引数から移動先のパネルを取得
        Transform targetPanel = GetPanel(targetState);

        // nullチェック
        if (!currentPanel || !targetPanel) return;

        // 移動先パネルを有効化
        targetPanel.gameObject.SetActive(true);

        // アニメーション
        _animationClass.Play(currentPanel.transform, _animMoveValue, _animDuration);
        _animationClass.Play(targetPanel.transform, -_animMoveValue, _animDuration);

        // 前に選択されていたステートを設定
        _previousSelectFlowState = _currentSelectFlowState;

        // 現在のステートを変更
        _currentSelectFlowState = targetState;

        // アニメーション時間分待機
        StartCoroutine(WaitAnimEnd(_animDuration));
    }

    /// <summary>
    /// 前のメニューに戻る
    /// </summary>
    public void BackMenu()
    {
        if (_currentSelectFlowState != ESelectFlowState.Mode)
            ChangeMenu(_previousSelectFlowState);
    }

    /// <summary>
    /// ステートを指定してパネルを取得する
    /// </summary>
    /// <param name="selectFlowState">対象ステート</param>
    /// <returns>対応するパネル</returns>
    private Transform GetPanel(ESelectFlowState selectFlowState)
    {
        switch (selectFlowState)
        {
            case ESelectFlowState.Mode:
                if (_modePanel) return _modePanel;
                break;
            case ESelectFlowState.Setting:
                if (_settingPanel) return _settingPanel;
                break;
            case ESelectFlowState.Difficulty:
                if (_difficultyPanel) return _difficultyPanel;
                break;
            default:
                Debug.LogError("指定されたステートが存在しません。");
                return null;
        }

        Debug.LogError("パネルが設定されていません");
        return null;
    }

    /// <summary>
    /// アニメーションの終了を待つ
    /// </summary>
    /// <param name="duration">待機秒数</param>
    /// <returns>yield</returns>
    private IEnumerator WaitAnimEnd(float duration)
    {
        _canChangeMenu = false;
        yield return new WaitForSeconds(duration + 0.1f);
        GetPanel(_previousSelectFlowState).gameObject.SetActive(false);
        _canChangeMenu = true;
    }
}
