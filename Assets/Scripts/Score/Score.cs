using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour { 


    public float ScoreValue = 0;

    [SerializeField]
    private GlobalOneFloatEvent _scoreUpdated;

    [SerializeField]
    private GlobalOneFloatEvent _highScoreUpdated;


    private float _highestScore = 0;



    [SerializeField]
    private GlobalEvent _gameOver;

    public void OnScoreRequestUpdate(float deltaScore)
    {

        if(_highestScore + deltaScore > _highestScore)
        {
            _highestScore = _highestScore + deltaScore;
            RaiseHighScoreUpdated();
        }

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

    private void RaiseHighScoreUpdated()
    {
        if (_highScoreUpdated != null)
        {
            _highScoreUpdated.Raise(_highestScore);
        }
    }

}
