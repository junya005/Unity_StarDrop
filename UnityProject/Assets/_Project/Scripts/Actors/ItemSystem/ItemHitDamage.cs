using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Junya005.ReverseDiver.InGame
{
    public class ItemHitDamage : ItemHitAction
    {
        protected override void HitAction(GameObject hitObj)
        {
            if (hitObj.transform.root.TryGetComponent<Player>(out var playerComponent))
            {
                IPlayerHP playerHP = playerComponent;
                playerHP.TakeDamage(_itemData.DataResource.damagePoint);
            }
        }
    }
}
