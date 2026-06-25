using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{
    [SerializeField]
    private float _animScale = 5.0f;

    private float _time = 0.0f;

    private Vector3 _initialPos = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _initialPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        SinAnimation(_time);

        if (_time >= 180.0f)
        {
            _time = 0.0f;
        }
    }

    public void SinAnimation(float t)
    {
        this.transform.position = new Vector3(_initialPos.x, _initialPos.y + Mathf.Sin(t) * _animScale, _initialPos.z);
    }
}
