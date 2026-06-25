using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ライトを回転させるクラス
/// </summary>
public class LightRotater : MonoBehaviour
{
    /// <summary>
    /// ライトのオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject _lightObject;

    /// <summary>
    /// ライトの回転スピード
    /// </summary>
    [SerializeField]
    private float _rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ライトを回転
        _lightObject.transform.Rotate(0.0f, 0.0f, _rotateSpeed * Time.deltaTime);
    }
}
