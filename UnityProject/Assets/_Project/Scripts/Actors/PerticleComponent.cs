using System.Collections.Generic;
using UnityEngine;

public class PerticleComponent : MonoBehaviour
{
    /// <summary>
    /// 使用するパーティクルのメタデータリスト
    /// </summary>
    [SerializeField]
    protected List<EffectMetaData> _perticleList;

    /// <summary>
    /// 使用するパーティクルの連想配列
    /// </summary>
    protected Dictionary<string, ParticleSystem> _perticleDictionary = new Dictionary<string, ParticleSystem>();

    // Start is called before the first frame update
    protected void Start()
    {
        // リストに設定されたメタデータから連想配列を作成
        if (_perticleList != null)
        {
            // 連想配列にデータを格納
            foreach (EffectMetaData effectData in _perticleList)
            {
                _perticleDictionary[effectData.Name] = effectData.Particle;
                Debug.Log($"パーティクルを配列に追加しました。(Key:{effectData.Name}, Value:{_perticleDictionary[effectData.Name]})");
            }

            // 念のためエフェクトをすべて停止させておく
            foreach (ParticleSystem particle in _perticleDictionary.Values)
            {
                particle.Stop();
            }
        }
    }

    /// <summary>
    /// パーティクルを名前指定で再生
    /// </summary>
    /// <param name="particleName">EffectMetaDataに設定してある名前で指定</param>
    public void PlayParticle(string particleName)
    {
        if (_perticleDictionary.TryGetValue(particleName, out var particle))
        {
            particle.Play();
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("パーティクルを再生できませんでした。");
#endif
        }
    }

    /// <summary>
    /// パーティクルを名前指定で停止
    /// </summary>
    /// <param name="particleName">EffectMetaDataに設定してある名前で指定</param>
    public void StopParticle(string particleName)
    {
        if (_perticleDictionary.TryGetValue(particleName, out var particle))
        {
            particle.Stop();
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("パーティクルを停止できませんでした。");
#endif
        }
    }
}
