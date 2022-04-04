using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UIMarketGridParent;

    [SerializeField]
    private GameObject UIMarektGridElementPrefab;


    public void OnMarketPrepared(Market market)
    {

        foreach (var satisfier in market.StartMarketSatisfiers)
        {
            GameObject uiStockGridElement = Instantiate(UIMarektGridElementPrefab, UIMarketGridParent.transform);
            uiStockGridElement.GetComponent<MarketStoreElementUI>().SetSatisfierElementUI(satisfier, 1);
        }
    }
}
