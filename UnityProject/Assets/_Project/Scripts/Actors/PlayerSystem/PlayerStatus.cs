using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステータスを表すクラス
/// </summary>
public class PlayerStatus : MonoBehaviour, IStatus
{
    // ゲージ系が空になった時のイベントを定義
    public event EmptyHPEvent emptyHPEventHandler;
    public event EmptyEnergyEvent emptyEnergyEventHandler;

    /// <summary>プレイヤーのステータスデータ</summary>
    [SerializeField]
    private SOPlayerCharacterStatus _characterStatus;

    public SOPlayerCharacterStatus StatusData { get { return _characterStatus; } }

    // パラメータのクラス
    private RangedValueFloat _hpClass;
    private RangedValueFloat _energyClass;

    // パラメータクラスのゲッター
    public RangedValueFloat HpClass { get { return _hpClass; } }
    public RangedValueFloat EnergyClass { get { return _energyClass; } }

    // その他のパラメータのゲッター
    public float MoveSpeed { get { return _characterStatus.moveSpeed; } }

    // Start is called before the first frame update
    void Awake()
    {
        // パラメータクラスのインスタンス
        _hpClass = new RangedValueFloat(_characterStatus.hpMax);
        _energyClass = new RangedValueFloat(_characterStatus.energyMax);

        // パラメータクラスの空イベントに関数を登録
        _hpClass.rangedValueEmptyEventHandler += OnEmptyHP;
        _energyClass.rangedValueEmptyEventHandler += OnEmptyEnergy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDestroy()
    {
        // イベントを登録解除
        _hpClass.rangedValueEmptyEventHandler -= OnEmptyHP;
        _energyClass.rangedValueEmptyEventHandler -= OnEmptyEnergy;
    }

    /// <summary>
    /// HPが空になった時の処理
    /// </summary>
    private void OnEmptyHP()
    {
        if (emptyHPEventHandler != null)
            emptyHPEventHandler.Invoke();
    }

    /// <summary>
    /// Energyが空になった時の処理
    /// </summary>
    private void OnEmptyEnergy()
    {
        if (emptyEnergyEventHandler != null)
            emptyEnergyEventHandler.Invoke();
    }

    /// <summary>
    /// HPが空になった場合のイベントに処理をバインドする
    /// </summary>
    public void BindEmptyHPEvent(EmptyHPEvent handler)
    {
        emptyHPEventHandler += handler;
    }
}
