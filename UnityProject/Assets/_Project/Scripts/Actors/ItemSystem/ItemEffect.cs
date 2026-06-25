using UnityEngine;

public class ItemEffect : MonoBehaviour
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
        {
            GameObject effect = Instantiate(_effectObject, this.transform.position, Quaternion.identity);
        }
    }
}
