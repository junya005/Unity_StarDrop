using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    public class ItemData : MonoBehaviour
    {
        [SerializeField]
        private SOItemData _dataResource;

        public SOItemData DataResource { get { return _dataResource; } }
    }
}
