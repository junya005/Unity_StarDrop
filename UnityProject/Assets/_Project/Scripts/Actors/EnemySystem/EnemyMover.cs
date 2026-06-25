using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _enemyRb2D;

    private Vector2 _moveValue;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float xRangeAbs = 7.0f;

    private bool _isCompleteInitMove;
    private bool _isMovingRight;

    public void Initialize(Rigidbody2D rb2d)
    {
        _enemyRb2D = rb2d;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isCompleteInitMove = false;
        _isMovingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyRb2D.velocity = _moveValue;

        if (_enemyRb2D.gravityScale == 0.0f)
        {
            int moveValueSign = _isMovingRight ? 1 : -1;
            _moveValue = new Vector2(_moveSpeed * moveValueSign, Mathf.Sin(DateTime.Now.Second) * 0.5f);

            if (this.transform.position.x >= xRangeAbs)
            {
                if (!_isCompleteInitMove && _isMovingRight)
                    _isCompleteInitMove = true;
                else if (_isCompleteInitMove && _isMovingRight)
                    _isMovingRight = false;
            }
            else if (this.transform.position.x <= -xRangeAbs)
            {
                if (!_isCompleteInitMove && !_isMovingRight)
                    _isCompleteInitMove = true;
                else if (_isCompleteInitMove && !_isMovingRight)
                    _isMovingRight = true;
            }
        }
    }

    void FixedUpdate()
    {

    }

    public void UseGravity(bool isUse, float scale = 1.0f)
    {
        if (isUse)
            _enemyRb2D.gravityScale = scale;
        else
            _enemyRb2D.gravityScale = 0.0f;
    }

    public void SetIsMovingRight(bool value)
    {
        _isMovingRight = value;
    }
}
