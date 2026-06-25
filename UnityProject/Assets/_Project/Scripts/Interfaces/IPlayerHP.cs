public interface IPlayerHP
{
    public void BindEmptyHPEvent(EmptyHPEvent handler);
    public void TakeDamage(float value);
    public void TakeHeal(float value);
}
