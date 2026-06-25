using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムデータのScriptableObject
/// </summary>
[Serializable, CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObject/ItemData")]
public class SOItemData : ScriptableObject
{
    public int itemID;
    public Sprite itemGraphyic;
    public GameObject effect;
    public int scorePoint;
    public float damagePoint;
    public float healHPPoint;
    public float healEnergyPoint;
}
