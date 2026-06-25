using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ミドルウェアにPlayerInputActionsのイベントをバインドするクラス
/// </summary>
public class PlayerInputBridge : MonoBehaviour
{
    /// <summary>PlayerのInputActionAsset</summary>
    public PlayerInputActions _playerInputActions;

    void Start()
    {
        // InputActionAssetのインスタンス
        _playerInputActions = new PlayerInputActions();

        // ボタンと関数のバインド
        _playerInputActions.GamePlay.Move.started += OnMove;
        _playerInputActions.GamePlay.Move.performed += OnMove;
        _playerInputActions.GamePlay.Move.canceled += OnMove;
        // _playerInputActions.GamePlay.Dush.started += OnDush;

        // Inputの有効化
        _playerInputActions.Enable();
    }

    private void OnDestroy()
    {
        // 登録解除
        _playerInputActions.GamePlay.Move.started -= OnMove;
        _playerInputActions.GamePlay.Move.performed -= OnMove;
        _playerInputActions.GamePlay.Move.canceled -= OnMove;

        _playerInputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputMiddleware.Instance?.OnInput("Move", context);
    }

    // public void OnDush(InputAction.CallbackContext context)
    // {
    //     InputMiddleware.Instance?.OnInput("Dush", context);
    // }
}
