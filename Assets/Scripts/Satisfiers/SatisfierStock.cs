using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SatisfierStock : MonoBehaviour
{
    public Dictionary<Satisfier, int> StockedSatisfiers;
    public UnityEvent<SatisfierStock> StockedChanged;

    public List<Satisfier> StartStockedSatisfiers;


    private void Awake()
    {
        StockedSatisfiers = new Dictionary<Satisfier, int>();       

        if(StartStockedSatisfiers != null && StartStockedSatisfiers.Count > 0)
        {
            foreach (Satisfier satisfier in StartStockedSatisfiers)
            {
                AddStockSatisfier(satisfier);
            }
        }
    }

    public void FillSatisfierStockForMonsterNeeds(MonsterNeeds monsterNeeds)
    {
        List<NeedCategory> needs = monsterNeeds.Needs;

        if(needs.Count == 0)
        {
            Debug.LogError("[SatisfierStock]: ZeroNeeds available");
        }

        for (int i = 0; i < monsterNeeds.NeedyLevel; i++)
        {
            Need n = needs[i].GetNeed();
            int randomIndex = Random.Range(0, n.PossibleSatisfiers.Count);

            AddStockSatisfier(n.PossibleSatisfiers[randomIndex]);
        }
        
        RaiseStockedChanged();
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
