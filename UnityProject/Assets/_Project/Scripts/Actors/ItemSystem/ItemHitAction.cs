using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    public class ItemHitAction : MonoBehaviour
    {
        public delegate void ItemHitEvent();
        public event ItemHitEvent itemHitEventHandler;
        public event ItemHitEvent itemHitEnemyEventHandler;

        protected ItemData _itemData;

        public void Initialize(ItemData itemData)
        {
            _itemData = itemData;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject hitObj = collision.gameObject;
                Debug.Log(hitObj);
                HitAction(hitObj);
                itemHitEventHandler.Invoke();
            }

            if (collision.gameObject.tag == CustomTagConstants.TAG_NAME_ENEMY)
            {
                if (itemHitEnemyEventHandler != null)
                    itemHitEnemyEventHandler.Invoke();
            }
        }

        protected virtual void HitAction(GameObject hitObj)
        {
            // スコアを加算
            ScoreManager.Instance?.AddScore(_itemData.DataResource.scorePoint);

            // プレイヤーにダメージ付与
            if (hitObj.transform.root.TryGetComponent<Player>(out var playerComponent))
            {
                IPlayerHP playerHP = playerComponent;
                playerHP.TakeDamage(_itemData.DataResource.damagePoint);
            }
        }
    }
}
