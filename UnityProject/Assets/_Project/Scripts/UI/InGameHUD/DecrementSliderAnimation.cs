using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DecrementSliderAnimation : MonoBehaviour
{
    [SerializeField]
    private DisplayValueSlider _targetDispValSlider;

    [SerializeField]
    private Transform _fillUIObjct;

    private Vector3 _fillUIObjInitPos;

    // Start is called before the first frame update
    void Start()
    {
        _fillUIObjInitPos = _fillUIObjct.position;

        if (_targetDispValSlider)
        {
            _targetDispValSlider.changedValueEventHandler += OnDisplay;
        }
    }

    private void OnDisplay(bool isIncreased)
    {
        _fillUIObjct.DOMove(_fillUIObjInitPos + Vector3.left, 0.1f)
                            .SetLoops(2, LoopType.Yoyo);
    }
}
