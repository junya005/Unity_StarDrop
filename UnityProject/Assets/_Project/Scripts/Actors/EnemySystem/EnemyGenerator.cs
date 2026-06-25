using System.Collections;
using System.Collections.Generic;
using Project.AudioSystem;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _spawnPosYRangeAbs = 3.0f;

    [SerializeField]
    private float _generateTimeSpan = 10.0f;

    [SerializeField]
    private float _randomTimeSpanRangeAbs = 0.0f;

    private float _timeSpanRangeValue;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_time > _generateTimeSpan + _timeSpanRangeValue)
        {
            int randomMovingRight = Random.Range(0, 2);
            Debug.Log(randomMovingRight);
            bool isMovingRight = randomMovingRight == 1 ? true : false;
            int spawnPosXSign = randomMovingRight == 1 ? 1 : -1;
            Vector2 spawnPos = new Vector2(-10.0f * spawnPosXSign, Random.Range(-_spawnPosYRangeAbs, _spawnPosYRangeAbs));
            GameObject enemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetIsMovingRight(isMovingRight);
            _time = 0.0f;
            _timeSpanRangeValue = Random.Range(-_randomTimeSpanRangeAbs, _randomTimeSpanRangeAbs);

            SoundManager.Instance.PlaySE(AudioNameConstants.SE_UFO_COMMING);
        }
    }
}
