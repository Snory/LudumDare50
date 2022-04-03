using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SatisfierStockElementUI : MonoBehaviour
{

    [SerializeField]
    private SatisfierEvent _requestToUseSatisfier;

    [SerializeField]
    private Image SatisfierImage;

    [SerializeField]
    private TextMeshProUGUI CountText;

    private Satisfier _satisfier;

    public void RaiseRequestToUseSatisfier()
    {
        if (_requestToUseSatisfier != null)
        {
            _requestToUseSatisfier.Raise(_satisfier);
        }
    }


    public void SetSatisfierElementUI(Satisfier s, int countOfSatisfiers)
    {
        _satisfier = s;
        SatisfierImage.sprite = _satisfier.SatisfierSprite;
        CountText.text = countOfSatisfiers.ToString();

    }


}
