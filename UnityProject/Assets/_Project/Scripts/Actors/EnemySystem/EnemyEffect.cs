using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _effectObject;

    public void Initialize(GameObject effectObj)
    {
        _effectObject = effectObj;
    }

    public void GenerateEffect()
    {
        if (_effectObject != null)
            Instantiate(_effectObject, this.transform.position, quaternion.identity);
    }
}
