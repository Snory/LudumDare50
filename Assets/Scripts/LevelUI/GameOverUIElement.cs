using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUIElement : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI GameOverHighScoreText;

    private void Awake()
    {
        GameOverHighScoreText.text = "Your high score is: 0";
    }
    public void OnHighScoreUpdated(float value)
    {
        GameOverHighScoreText.text = "Your high score is: " + value.ToString();
    }

}
