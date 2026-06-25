using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(100)]
public class PlayerUIOutput : MonoBehaviour
{
    [SerializeField]
    private PlayerStatus _playerStatus;

    [SerializeField]
    private DisplayValueSlider _hpOutSlider;

    [SerializeField]
    private DisplayValueSlider _energyOutSlider;

    private void Start()
    {
        _playerStatus.HpClass.changedCurrentValueEventHandler += OutputTargetUI;
    }

    public void OutputTargetUI(bool isIncreased)
    {
        Debug.Log(_playerStatus);

        if (!_playerStatus) return;

        if (_hpOutSlider)
        {
            _hpOutSlider.displayValueEventHandler?.Invoke
            (
                _playerStatus.HpClass.RangedValueCurrent,
                _playerStatus.HpClass.RangedValueMax
            );
        }
        if (_energyOutSlider)
        {
            _energyOutSlider.displayValueEventHandler?.Invoke
            (
                _playerStatus.EnergyClass.RangedValueCurrent,
                _playerStatus.EnergyClass.RangedValueMax
            );
        }
    }
}
