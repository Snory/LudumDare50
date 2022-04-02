using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SatisfierStock : MonoBehaviour
{
    public Dictionary<Satisfier, int> StockedSatisfiers;
    private List<MonsterNeeds> _monsterNeedsToFill;
        
    public UnityEvent<SatisfierStock> StockedChanged;

    private void Awake()
    {
        StockedSatisfiers = new Dictionary<Satisfier, int>();
        _monsterNeedsToFill = new List<MonsterNeeds>();
        
    }

    public void FillSatisfierStockForMonsterNeeds()
    {
        EmptyStockSatisfier();

        foreach (MonsterNeeds monsterNeeds in _monsterNeedsToFill)
        {
            List<NeedCategory> needs = monsterNeeds.Needs;
            for (int i = 0; i < monsterNeeds.NeedyLevel; i++)
            {
                Need n = needs[i].GetNeed();
                int randomIndex = Random.Range(0, n.PossibleSatisfiers.Count);

                AddStockSatisfier(n.PossibleSatisfiers[randomIndex]);
            }
        }
        RaiseStockedChanged();
    }

    public void AddMonsterNeedsToFill(MonsterNeeds monsterNeeds)
    {
        if(_monsterNeedsToFill == null)
        {
            Debug.Log("WTF");
        }
        _monsterNeedsToFill.Add(monsterNeeds);
    }


    public void AddStockSatisfier(Satisfier s)
    {
        //èeknout jestli už existuje
        if (StockedSatisfiers.ContainsKey(s))
        {
            StockedSatisfiers[s] += 1;
        } else
        {
            StockedSatisfiers.Add(s, 1);
        }
    }


    public void RemoveStockSatisfier(Satisfier s)
    {
        //èeknout jestli už existuje
        if (StockedSatisfiers.ContainsKey(s))
        {
            if(StockedSatisfiers[s] == 1)
            {
                StockedSatisfiers.Remove(s);
            } else
            {
                StockedSatisfiers[s] -= 1;
            }
        }

        RaiseStockedChanged();
    }

    public void EmptyStockSatisfier()
    {
        StockedSatisfiers.Clear();
    }


    private void RaiseStockedChanged()
    {
        if(StockedChanged!= null)
        {
            StockedChanged.Invoke(this);
        }
    }


}
