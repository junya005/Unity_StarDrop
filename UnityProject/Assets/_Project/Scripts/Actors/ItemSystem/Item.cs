using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    /*
    プレイヤーが取得できるアイテム

    コンポジットは以下の通り
    ItemData:アイテムの詳細データを保持する
    ItemMover:アイテムの移動を担当する
    ItemHitAction:アイテムの衝突イベントを管理する
    */

    /// <summary>登場するアイテムを表すクラス</summary>
    public class Item : MonoBehaviour, IItem
    {
        [SerializeField]
        private ItemData _itemData;

        [SerializeField]
        private ItemMover _itemMover;

        [SerializeField]
        private ItemHitAction _itemHitAction;

        [SerializeField]
        private ItemEffect _itemEffect;

        // Start is called before the first frame update
        void Start()
        {
            _itemMover.Initialize(this.transform);
            _itemHitAction.Initialize(_itemData);
            _itemEffect.Initialize(_itemData.DataResource.effect);

            SubscribeEvents();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SubscribeEvents()
        {
            _itemMover.BindItemDiscardPosEvent(DestroyItem);
            _itemHitAction.itemHitEventHandler += GenEffect;
            _itemHitAction.itemHitEventHandler += DestroyItem;
            _itemHitAction.itemHitEnemyEventHandler += DecrementScore;
            _itemHitAction.itemHitEnemyEventHandler += DestroyItem;
        }

        private void GenEffect()
        {
            _itemEffect.GenerateEffect();
        }

        private void DestroyItem()
        {
            Destroy(this.gameObject);
        }

        private void DecrementScore()
        {
            ScoreManager.Instance.AddScore(-10);
        }

        public void Move(Vector2 direction, float power)
        {
            _itemMover.Move(direction, power);
        }
    }
}
