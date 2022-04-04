using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoNeedElementUI : MonoBehaviour
{

    [SerializeField]
    private Image _iconImage;
    
    [SerializeField]
    private TextMeshProUGUI _levelText;


    public void SetInfoNeedElementUI(Sprite iconImage, float level)
    {
        _iconImage.sprite = iconImage;
        _levelText.text = level.ToString();
    }
    
}
