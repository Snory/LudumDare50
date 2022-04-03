using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    private float _score;
    public TextMeshProUGUI Text;

    [SerializeField]
    private GlobalEvent _gameOver;


    public void OnScoreUpdate(float value)
    {
        _score += value;
        Text.text = "Score: " + _score.ToString();

        if(_score < 0)
        {
            if(_gameOver != null)
            {
                _gameOver.Raise();
            }
        }
    }



}
