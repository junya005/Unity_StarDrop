using System.Collections;
using System.Collections.Generic;
using Project.AudioSystem;
using UnityEngine;

/// <summary>プレイヤーの移動を担当するクラス</summary>
public class PlayerMover : MonoBehaviour
{
    /// <summary>プレイヤーのRigidbodyコンポーネントを格納</summary>
    [SerializeField]
    private Rigidbody2D _playerRb;

    private float _moveSpeed;

    [SerializeField]
    private float _speedLimit;

    [SerializeField]
    private float _dropSpeedRate = 1.2f;

    private Vector2 _moveValue;

    public Vector2 MoveValue { get { return _moveValue; } }

    private bool _isDropping;
    public bool IsDropping { get { return _isDropping; } }

    private Coroutine _coroutine;

    private void Update()
    {
        if (_moveValue.y < -0.1f && _moveValue.x < Mathf.Abs(0.5f))
        {
            if (!_isDropping)
            {
                _isDropping = true;
                _coroutine = StartCoroutine(Hop());
                SoundManager.Instance.PlaySE(AudioNameConstants.SE_DROP);
            }
        }
        else
        {
            if (_isDropping)
            {
                _isDropping = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private void FixedUpdate()
    {
        // ここから物理演算
        if (_playerRb == null) return;

        // ヒップドロップの挙動と分けるためy軸の入力値を切り離す
        Vector2 moveValue = new Vector2(_moveValue.x, 0.0f);

        // 速度減衰(自然に停止させるため)
        _playerRb.velocity *= 0.9f;

        // ヒップドロップ
        if (_isDropping)
        {
            _playerRb.AddForce(Vector2.down * _moveSpeed * _dropSpeedRate);
        }
        else
        {
            _playerRb.AddForce(moveValue * _moveSpeed);
        }

        // 速度制限を設ける
        if (Mathf.Abs(_playerRb.velocity.x) > _speedLimit)
        {
            float limitValueX = Mathf.Sign(_playerRb.velocity.x) * _speedLimit;
            _playerRb.velocity = new Vector2(limitValueX, _playerRb.velocity.y);
        }

        if (Mathf.Abs(_playerRb.velocity.y) > _speedLimit)
        {
            float limitValueY = Mathf.Sign(_playerRb.velocity.y) * _speedLimit;
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, limitValueY);
        }
    }

    /// <summary>
    /// 移動する
    /// </summary>
    /// <param name="inputValue"></param>
    public void Move(Vector2 inputValue, float moveSpeed)
    {
        _moveValue = inputValue;
        _moveSpeed = moveSpeed;
    }

    public void Dush(float dushPower)
    {
        _playerRb.AddForce(_moveValue * dushPower, ForceMode2D.Impulse);
    }

    private IEnumerator Hop()
    {
        _playerRb.AddForce(Vector2.up * 10.0f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        _playerRb.AddForce(Vector2.down * 10.0f, ForceMode2D.Impulse);
    }
}
