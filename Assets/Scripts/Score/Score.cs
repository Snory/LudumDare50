using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour { 


    public float ScoreValue = 0;

    [SerializeField]
    private GlobalOneFloatEvent _scoreUpdated;


    [SerializeField]
    private GlobalEvent _gameOver;

    public void OnScoreRequestUpdate(float deltaScore)
    {
        ScoreValue += deltaScore;

        if (ScoreValue < 0)
        {
            if (_gameOver != null)
            {
                _gameOver.Raise();
            }
        }

        RaiseScoreUpdated();
    }

    private void RaiseScoreUpdated()
    {
        if(_scoreUpdated != null)
        {
            _scoreUpdated.Raise(ScoreValue);
        }
    }

}
