using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitAction : MonoBehaviour
{
    public delegate void PlayerHitColliderEvent();
    public event PlayerHitColliderEvent playerHitColliderEventHandler;

    public delegate void PlayerHitTriggerEvent();
    public event PlayerHitTriggerEvent playerHitTriggerEventHandler;

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
