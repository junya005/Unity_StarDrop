using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [SerializeField]
    private PlayerHandler _playerHandler;

    [SerializeField]
    private PlayerMover _playerMover;

    [SerializeField]
    private PlayerStatus _playerStatus;

    [SerializeField]
    private PlayerEffect _playerEffect;

    [SerializeField]
    private PlayerUIOutput _playerUIOutput;

    // Start is called before the first frame update
    void Start()
    {
        if (_playerHandler)
        {
            _playerHandler.moveEventHandler += OnMoveEvent;
            _playerHandler.dushEventHandler += OnDushEvent;
        }

        if (_playerStatus)
        {
            _playerStatus.HpClass.changedCurrentValueEventHandler += OnChangedHP;
        }

        if (_playerUIOutput)
        {
            _playerUIOutput.OutputTargetUI(_playerStatus);
        }
    }

    private void OnMoveEvent(Vector2 moveValue)
    {
        _playerMover.Move(moveValue, _playerStatus.StatusData.moveSpeed);

        if (moveValue.y < -0.1f && moveValue.x < Mathf.Abs(0.5f))
        {
            _playerEffect?.PlayParticle("DropStar");
            _playerEffect?.PlayParticle("DropTrail");
        }
        else
        {
            _playerEffect?.StopParticle("DropStar");
            _playerEffect?.StopParticle("DropTrail");
        }
    }

    private void OnDushEvent()
    {
        _playerMover?.Dush(_playerStatus.StatusData.dushPower);
    }

    private void OnChangedHP(bool isIncreased)
    {
        _playerUIOutput?.OutputTargetUI(_playerStatus);
    }

    /// <summary>
    /// HPが空になった場合のイベントに処理をバインドする
    /// </summary>
    public void BindEmptyHPEvent(EmptyHPEvent handler)
    {
        _playerStatus?.BindEmptyHPEvent(handler);
    }

    public void TakeDamage(float value)
    {
        _playerStatus?.HpClass.Decrease(value);
    }

    public void TakeHeal(float value)
    {
        _playerStatus?.HpClass.Increase(value);
    }

    public bool GetIsDropping()
    {
        return _playerMover.IsDropping;
    }
}
