using System.Collections;
using System.Collections.Generic;
using Project.AudioSystem;
using UnityEngine;

public class EnemyHitAction : MonoBehaviour
{
    public delegate void EnemyHitEvent();
    public event EnemyHitEvent enemyHitPlayerEventHandler;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IPlayerHP playerHP = null;
            IPlayerPropertys playerPropertys = null;
            if (collision.transform.root.TryGetComponent<Player>(out var playerComponent))
            {
                playerHP = playerComponent;
                playerPropertys = playerComponent;
            }

            if (collision.transform.position.y >= this.transform.position.y)
            {
                if (!playerPropertys.GetIsDropping()) return;
                HitStopManager.Instance?.StartHitStop();
                if (enemyHitPlayerEventHandler != null)
                    enemyHitPlayerEventHandler.Invoke();
                if (this.TryGetComponent<Collider2D>(out var component))
                    component.enabled = false;

                SoundManager.Instance.PlaySE(AudioNameConstants.SE_UFO_IMPACT);
            }
            else
            {
                Debug.Log("Damage!");
                playerHP.TakeDamage(40);
            }
        }
    }
}
