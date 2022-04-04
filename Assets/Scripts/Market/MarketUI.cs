using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UIMarketGridParent;

    [SerializeField]
    private GameObject UIMarektGridElementPrefab;

    private List<MarketStoreElementUI> _uiMarketStoreElements;

    private void Awake()
    {
        _uiMarketStoreElements = new List<MarketStoreElementUI>();
    }

    public void OnMarketPrepared(Market market)
    {

        foreach (var satisfier in market.StartMarketSatisfiers)
        {
            MarketStoreElementUI uiMarketGridElement = Instantiate(UIMarektGridElementPrefab, UIMarketGridParent.transform).GetComponent<MarketStoreElementUI>();
            _uiMarketStoreElements.Add(uiMarketGridElement);
            uiMarketGridElement.SetSatisfierElementUI(satisfier, satisfier.SatisfierPrice);
        }
    }


    public void OnScoreUpdate(float newScore)
    {
        //run through each item and disable best on the price
        for (int i = 0; i < _uiMarketStoreElements.Count; i++)
        {
            if(_uiMarketStoreElements[i].AssignedSatisfier.SatisfierPrice <= newScore)
            {
                _uiMarketStoreElements[i].SetInteractable(true);
            } else
            {
                _uiMarketStoreElements[i].SetInteractable(false);
            }
        }
    }
   
}
