using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreUIElement : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        HighScoreText.text = "0";
    }
    public void OnHighScoreUpdated(float value)
    {
        HighScoreText.text =  value.ToString();
    }

}
