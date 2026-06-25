using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エフェクトのメタデータを表すクラス
/// </summary>
/// <remarks>
/// 必ずParticleSystemとセットで使用
/// </remarks>
[RequireComponent(typeof(ParticleSystem))]
public class EffectMetaData : MonoBehaviour
{
    /// <summary>
    /// エフェクト名
    /// </summary>
    [SerializeField]
    private string _name;

    /// <summary>
    /// [フックプロパティ]エフェクト名
    /// </summary>
    public string Name { get { return _name; } }

    /// <summary>
    /// [フックプロパティ]パーティクルデータ
    /// </summary>
    public ParticleSystem Particle { get; private set; }

    private void Awake()
    {
        // 同オブジェクトにあるパーティクルコンポーネントを格納
        if (this.gameObject.TryGetComponent<ParticleSystem>(out var particle))
        {
            Particle = particle;
        }
    }
}
