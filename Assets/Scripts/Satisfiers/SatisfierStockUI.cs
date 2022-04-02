using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatisfierStockUI : LevelUIElement
{

    [SerializeField]
    private GameObject UIStockGridParent;


    [SerializeField]
    private GameObject UIStockGridElementPrefab;

    private List<GameObject> _uiStockGridElements;
    
    private SatisfierStock _stockSatisfier;

    private void Awake()
    {
        _uiStockGridElements = new List<GameObject>();
    }

    public void UpdateStockUI(SatisfierStock stock)
    {
        ClearStockGrid();
        _stockSatisfier = stock;
        foreach(var satisfier in _stockSatisfier.StockedSatisfiers)
        {
            GameObject uiStockGridElement = Instantiate(UIStockGridElementPrefab, UIStockGridParent.transform);
            uiStockGridElement.GetComponent<SatisfierStockElementUI>().Satisfier = satisfier.Key;
            _uiStockGridElements.Add(uiStockGridElement);
        }
    }

    private void ClearStockGrid()
    {
        for (int i = 0; i < UIStockGridParent.transform.childCount; i++)
        {
            Destroy(UIStockGridParent.transform.GetChild(i).gameObject);
        }
    }



    

}
