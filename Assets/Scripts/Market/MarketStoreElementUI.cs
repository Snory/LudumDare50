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

    private Satisfier _assignedSatisfier;

    public Satisfier AssignedSatisfier { get => _assignedSatisfier; }

    [SerializeField]
    private Button _button;


    public void RaiseRequestToBuySatisfier()
    {
        if (_requestToBuySatisfier != null)
        {
            _requestToBuySatisfier.Raise(_assignedSatisfier);
        }
    }


    public void SetSatisfierElementUI(Satisfier s, float priceOfSatisfier)
    {
        _assignedSatisfier = s;
        SatisfierImage.sprite = _assignedSatisfier.SatisfierSprite;
        CountText.text = priceOfSatisfier.ToString();
        SetInteractable(false);     
    }

    public void SetInteractable(bool interactable)
    {
        _button.interactable = interactable;
    }
    
}
