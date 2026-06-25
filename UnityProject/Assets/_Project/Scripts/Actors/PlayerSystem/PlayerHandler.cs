using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    /// <summary>移動ボタンのイベント</summary>
    public event InputEventMove moveEventHandler;

    /// <summary>移動ボタンのイベント</summary>
    public event InputEventDush dushEventHandler;

    // Start is called before the first frame update
    void Start()
    {
        // ミドルウェアに処理を登録
        InputMiddleware.Instance?.Bind("Move", OnMove);
        InputMiddleware.Instance?.Bind("Dush", OnDush);
    }

    /// <summary>
    /// 移動ボタン押下時に実行する関数
    /// </summary>
    private void OnMove(InputAction.CallbackContext context)
    {
        moveEventHandler.Invoke(context.ReadValue<Vector2>());
    }

    /// <summary>
    /// ダッシュボタン押下時に実行する関数
    /// </summary>
    private void OnDush(InputAction.CallbackContext context)
    {
        dushEventHandler.Invoke();
    }
}
