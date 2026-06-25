using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public delegate void ChangeScoreEvent(int value);
    public event ChangeScoreEvent changeScoreEventHandler;

    private int _score;

    public int Score { get { return _score; } }

    public void SetScore(int value)
    {
        _score = value;

        ScoreToCorrect();

        changeScoreEventHandler.Invoke(_score);
    }

    public void AddScore(int value)
    {
        _score += value;

        ScoreToCorrect();

        changeScoreEventHandler.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void ScoreToCorrect()
    {
        if (_score <= 0)
        {
            _score = 0;
        }
    }
}
