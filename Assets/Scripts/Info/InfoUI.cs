using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _monsterDetails;

    [SerializeField]
    private GameObject UINeedGridParent;

    [SerializeField]
    private GameObject UINeedElementGridPrefab;

    private List<InfoNeedElementUI> _uiInfoNeedElements;

    [SerializeField]
    private TextMeshProUGUI _sellPerLevelText, _monsterTypeText, _maxStockLevelText, minSellLevelText;

    private MonsterNeeds _currentMonsterNeeds;

    private void Awake()
    {
        _uiInfoNeedElements = new List<InfoNeedElementUI>();
        _monsterDetails.SetActive(false);
    }

    public void OnInfoPrepared(MonsterNeeds monsterNeeds)
    {
        ClearInfoNeedGrid();
        for (int i = 0; i < monsterNeeds.MonsterType.Needs.Count; i++)
        {
            InfoNeedElementUI infoNeedGridElementUI = Instantiate(UINeedElementGridPrefab, UINeedGridParent.transform).GetComponent<InfoNeedElementUI>();
            _uiInfoNeedElements.Add(infoNeedGridElementUI);
            
            infoNeedGridElementUI.SetInfoNeedElementUI(monsterNeeds.MonsterType.Needs[i].CategoryIcon, i +1);

            _monsterTypeText.text =  monsterNeeds.MonsterType.ToString().Replace(" (MonsterType)", "");
            _sellPerLevelText.text = "Sale money per level: " + monsterNeeds.MonsterType.SellValuePerLevel.ToString();
            _maxStockLevelText.text = "Max stock level: " + monsterNeeds.MonsterType.MaximumStockGeneration.ToString();
            minSellLevelText.text = "Min sale level: " + monsterNeeds.MonsterType.MinimumSellLevel.ToString();
        }
        
    }

    private void ClearInfoNeedGrid()
    {
        for (int i = 0; i < UINeedGridParent.transform.childCount; i++)
        {
            Destroy(UINeedGridParent.transform.GetChild(i).gameObject);
        }
    }


    public void OnMonsterSelected(GameObject monster)
    {
        _currentMonsterNeeds = monster.GetComponent<MonsterNeeds>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_currentMonsterNeeds != null)
            {
                OnInfoPrepared(_currentMonsterNeeds);
                if (_monsterDetails.activeSelf)
                {
                    _monsterDetails.SetActive(false);
                } else
                {
                    _monsterDetails.SetActive(true);
                }
            }
        }
    }

}
