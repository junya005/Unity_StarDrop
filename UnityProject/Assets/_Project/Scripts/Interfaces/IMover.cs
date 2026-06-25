using UnityEngine;

public interface IMover
{
    public void Initialize(Rigidbody2D rb);
    public void Move(Vector2 inputValue, float moveSpeed);
}
