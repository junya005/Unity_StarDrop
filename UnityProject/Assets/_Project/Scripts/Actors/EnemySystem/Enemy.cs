using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int SCORE_POINT_ENEMY = 100;

    [SerializeField]
    private EnemyMover _enemyMover;

    [SerializeField]
    private EnemyHitAction _enemyHitAction;

    [SerializeField]
    private EnemyDisposer _enemyDisposer;

    [SerializeField]
    private TractorBeam _tractorBeam;

    [SerializeField]
    private EnemyEffect _enemyEffect;

    private void Awake()
    {
        if (gameObject.TryGetComponent<Rigidbody2D>(out var component))
            _enemyMover.Initialize(component);

        _enemyDisposer.Initialize(this.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_enemyHitAction)
            _enemyHitAction.enemyHitPlayerEventHandler += OnHitPlayer;
        if (_enemyDisposer)
            _enemyDisposer.enemyDisposeEventHandler += OnDispose;

        _tractorBeam.PlayTractorBeamEffect();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnHitPlayer()
    {
        if (_enemyMover)
            _enemyMover.UseGravity(true, 10.0f);

        _tractorBeam.StopTractorBeamEffect();
        _tractorBeam.gameObject.SetActive(false);
    }

    private void OnDispose()
    {
        _enemyEffect.GenerateEffect();
        ScoreManager.Instance.AddScore(SCORE_POINT_ENEMY);
        Destroy(this.gameObject);
    }

    public void SetIsMovingRight(bool value)
    {
        _enemyMover.SetIsMovingRight(value);
    }

}
