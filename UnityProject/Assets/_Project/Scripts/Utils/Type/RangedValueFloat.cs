using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedValueFloat : IRangedValueFloat
{
    public event ChangedValueEvent changedCurrentValueEventHandler;
    public event EmptyRangedValueEvent rangedValueEmptyEventHandler;

    private float _rangedValueMax;

    public float RangedValueMax { get { return _rangedValueMax; } }

    private float _rangedValueCurrent;

    public float RangedValueCurrent { get { return _rangedValueCurrent; } }

    private bool _isEmpty;

    public RangedValueFloat(float valueMax)
    {
        _rangedValueCurrent = valueMax;
        _rangedValueMax = valueMax;
    }

    public void SetRangedValueMax(float value)
    {
        _rangedValueMax = value;

        ValueRangeInCorrection();
    }

    public void SetRangedValueCurrent(float value)
    {
        _rangedValueCurrent = value;

        ValueRangeInCorrection();
    }

    public void Increase(float value)
    {
        _rangedValueCurrent += value;

        ValueRangeInCorrection();

        InvokeChangedValueEvent(true);

    }

    public void Decrease(float value)
    {
        Debug.Log(value);

        _rangedValueCurrent -= value;

        ValueRangeInCorrection();

        InvokeChangedValueEvent(false);
    }

    private void InvokeChangedValueEvent(bool isIncreased)
    {
        if (changedCurrentValueEventHandler != null)
            changedCurrentValueEventHandler.Invoke(isIncreased);
    }

    private void ValueRangeInCorrection()
    {
        if (_rangedValueCurrent >= _rangedValueMax)
        {
            _rangedValueCurrent = _rangedValueMax;
        }

        if (_rangedValueCurrent <= 0.0f)
        {
            _rangedValueCurrent = 0.0f;

            if (!_isEmpty)
            {
                _isEmpty = true;
                rangedValueEmptyEventHandler.Invoke();
            }
        }
    }
}
