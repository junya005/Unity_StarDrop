using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    public class ItemHitScore : ItemHitAction
    {
        protected override void HitAction(GameObject hitObj)
        {
            ScoreManager.Instance?.AddScore(_itemData.DataResource.scorePoint);
        }
    }
}
