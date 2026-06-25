public delegate void EmptyRangedValueEvent();

public interface IRangedValueFloat
{
    public event EmptyRangedValueEvent rangedValueEmptyEventHandler;

    public void SetRangedValueMax(float value);
    public void SetRangedValueCurrent(float value);
    public void Increase(float value);
    public void Decrease(float value);
}
