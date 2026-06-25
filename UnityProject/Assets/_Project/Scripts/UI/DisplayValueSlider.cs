using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayValueSlider : MonoBehaviour
{
    public ChangedValueEvent changedValueEventHandler;
    public DisplayRangeValueEvent displayValueEventHandler;

    [SerializeField]
    private Slider _targetSlider;

    private float _lastValue;

    private void Awake()
    {
        displayValueEventHandler += OnDisplay;
    }

    public void OnDisplay(float value, float valueMax)
    {
#if UNITY_EDITOR
        if (valueMax <= 0.0f)
        {
            Debug.LogWarning("最大値が想定外の範囲です");
        }
#endif

        _targetSlider.value = value / valueMax;

        if (value < _lastValue)
        {
            if (changedValueEventHandler != null)
                changedValueEventHandler.Invoke(false);
        }
        else if (value > _lastValue)
        {
            if (changedValueEventHandler != null)
                changedValueEventHandler.Invoke(true);
        }

        _lastValue = value;
    }
}
