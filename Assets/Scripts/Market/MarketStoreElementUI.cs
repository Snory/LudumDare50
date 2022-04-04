using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketStoreElementUI : MonoBehaviour
{
    [SerializeField]
    private SatisfierEvent _requestToBuySatisfier;

    [SerializeField]
    private Image SatisfierImage;

    [SerializeField]
    private TextMeshProUGUI CountText;

    private Satisfier _satisfier;


    public void RaiseRequestToBuySatisfier()
    {
        if (_requestToBuySatisfier != null)
        {
            _requestToBuySatisfier.Raise(_satisfier);
        }
    }


    public void SetSatisfierElementUI(Satisfier s, int countOfSatisfiers)
    {
        _satisfier = s;
        SatisfierImage.sprite = _satisfier.SatisfierSprite;
        CountText.text = countOfSatisfiers.ToString();

    }
}
