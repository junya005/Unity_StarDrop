using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _generateList;

    [SerializeField]
    private float _generateInterval = 2.0f;

    private float _time;

    [SerializeField]
    private float startPosX;

    [SerializeField]
    private float endPosX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _generateInterval && !(_generateList.Count <= 0))
        {
            int genIndex = Random.Range(0, _generateList.Count - 1);
            GameObject item = Instantiate(_generateList[genIndex]);
            item.transform.position = new Vector2(Random.Range(startPosX, endPosX), -10);
            _time = 0.0f;
        }
    }
}
