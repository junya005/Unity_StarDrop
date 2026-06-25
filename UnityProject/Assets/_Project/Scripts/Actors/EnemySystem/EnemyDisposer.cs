using UnityEngine;

public class EnemyDisposer : MonoBehaviour
{
    public delegate void EnemyDisposeEvent();
    public event EnemyDisposeEvent enemyDisposeEventHandler;

    private Transform _enemyTransform;

    [SerializeField]
    private float _disposePosY;

    public void Initialize(Transform enemyTransform)
    {
        _enemyTransform = enemyTransform;
    }

    private void Update()
    {
        if (!_enemyTransform) return;
        if (_enemyTransform.position.y <= _disposePosY)
        {
            if (enemyDisposeEventHandler != null)
            {
                enemyDisposeEventHandler.Invoke();
            }
        }
    }
}
