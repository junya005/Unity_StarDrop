using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayValueText : MonoBehaviour
{
    public event DisplayValueEvent displayValueEventHandler;

    [SerializeField]
    protected TextMeshProUGUI _displayText;

    private float _value;

    public float Value
    {
        set
        {
            _value = value;
            displayValueEventHandler?.Invoke(_value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        displayValueEventHandler += OnDisplay;
    }

    public void OnDisplay(float value)
    {
        _displayText.text = Mathf.RoundToInt(value).ToString();
    }
}
