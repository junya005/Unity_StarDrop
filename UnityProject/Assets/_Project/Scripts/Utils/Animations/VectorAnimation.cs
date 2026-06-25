using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vector型を使用したアニメーションの抽象クラス
/// </summary>
public abstract class VectorAnimation : MonoBehaviour
{
    public abstract void Play(Transform targetObj, Vector3 targetPos, float duration);
}
