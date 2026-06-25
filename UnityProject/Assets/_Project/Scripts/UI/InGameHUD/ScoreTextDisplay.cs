using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextDisplay : DisplayValueText
{
    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.Instance == null) return;
        ScoreManager.Instance.changeScoreEventHandler += OnChangeScore;
    }

    private void OnChangeScore(int value)
    {
        OnDisplay(value);
    }
}
