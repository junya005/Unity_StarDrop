using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "PCStatus")]
public class SOPlayerCharacterStatus : ScriptableObject
{
    public int playerId;
    public float hpMax;
    public float energyMax;
    public float moveSpeed;
    public float dushPower;
}
