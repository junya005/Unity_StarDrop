using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EffectController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (_particleSystem == null)
            _particleSystem = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_particleSystem == null) return;

        if (!_particleSystem.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
