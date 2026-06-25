/// <summary>
/// ステータスのインターフェース
/// </summary>
public interface IStatus
{
    public SOPlayerCharacterStatus StatusData { get; }

    // パラメータが空になった時のイベントを宣言
    public event EmptyHPEvent emptyHPEventHandler;
    public event EmptyEnergyEvent emptyEnergyEventHandler;

    // クラスのゲッターを宣言
    public RangedValueFloat HpClass { get; }
    public RangedValueFloat EnergyClass { get; }


}
