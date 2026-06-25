using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeInterface<T>
{
    [SerializeField]
    private GameObject _targetObject;

    private T _catchedInterface;

    public T CatchedInterface
    {
        get
        {
            if (_catchedInterface != null)
            {
                _catchedInterface = _targetObject.GetComponent<T>();
            }

            return _catchedInterface;
        }
    }
}
