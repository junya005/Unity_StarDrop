using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    public class ItemMover : MonoBehaviour
    {
        private event ItemArrivedAtDiscardPositionEvent _itemDiscardPosEventHandler;

        private Transform _itemTransform;

        [SerializeField]
        private float _itemDiscardPosY;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_itemTransform != null)
                _itemTransform.position += Vector3.up * 1.0f * Time.deltaTime;

            CheckItemPosForDiscard();
        }

        public void Initialize(Transform itemTransform)
        {
            _itemTransform = itemTransform;
        }

        public void Move(Vector2 direction, float power)
        {
            Vector3 d = new Vector3(direction.x, direction.y, 0.0f);
            _itemTransform.position += d * power;
        }

        /// <summary>
        /// アイテムを破棄する位置になったかチェックする
        /// </summary>
        private void CheckItemPosForDiscard()
        {
            if (_itemTransform.position.y > _itemDiscardPosY && _itemDiscardPosEventHandler != null)
                _itemDiscardPosEventHandler.Invoke();
        }

        public void BindItemDiscardPosEvent(ItemArrivedAtDiscardPositionEvent handler)
        {
            _itemDiscardPosEventHandler += handler;
        }
    }
}
