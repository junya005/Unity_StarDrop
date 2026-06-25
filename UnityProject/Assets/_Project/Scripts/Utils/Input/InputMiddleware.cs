using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Input Systemの入力を一括管理するミドルウェア
/// </summary>
public class InputMiddleware : Singleton<InputMiddleware>
{
    /// <summary>
    /// バインドしている入力イベントの連想配列
    /// </summary>
    private Dictionary<string, Action<InputAction.CallbackContext>> _bindings
        = new Dictionary<string, Action<InputAction.CallbackContext>>();

    /// <summary>
    /// 操作が有効かどうか
    /// </summary>
    private bool _enabled = true;

    /// <summary>
    /// [フックプロパティ]操作が有効かどうか
    /// </summary>
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    /// <summary>
    /// 入力イベントをバインド配列に追加
    /// </summary>
    /// <param name="actionName">PlayerInputのAction名</param>
    /// <param name="handler">実行するイベント</param>
    public void Bind(string actionName, Action<InputAction.CallbackContext> handler)
    {
        _bindings[actionName] = handler;
    }

    /// <summary>
    /// Input側で呼び出される共通ハンドラ
    /// </summary>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    public void OnInput(string actionName, InputAction.CallbackContext context)
    {
        // 入力が無効であれば実行しない
        if (!_enabled) return;

        // action名を探してあればイベントを呼び出し
        if (_bindings.TryGetValue(actionName, out var action))
        {
            action?.Invoke(context);
        }
    }
}
