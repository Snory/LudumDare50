using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MonsterNeeds : MonoBehaviour
{
    
    public UnityEvent<Need,bool> MonsterSatisfied;
    //variable list of category needs per level
    [SerializeField]
    private int _levelOfNeeds;
    public List<NeedCategory> Needs;
    //variable list of actual needs for given level

    private List<MonsterNeedSatisfier> _actualNeeds;
    //variable list of actual sources for given level
    //variable to store level index



    private void Start()
    {
        _actualNeeds = new List<MonsterNeedSatisfier>();
        GenerateActualNeeds();
    }

    public void GenerateActualNeeds()
    {
        _actualNeeds.Clear();

        for (int i = 0; i < _levelOfNeeds; i++)
        {
            Need n = Needs[i].GenerateNeed();
            Satisfier defaultSatisfier = Needs[i].DefaultSatisfier;
            Debug.Log(n.GetType());
            _actualNeeds.Add(new MonsterNeedSatisfier(n, defaultSatisfier));
        }
    }

    public void SatisfyNeeds()
    {

        for (int i = 0; i < _actualNeeds.Count; i++)
        {
            Need n = _actualNeeds[i].Need;
            Satisfier s = _actualNeeds[i].Satisfier;
            bool satisfied = n.SatisfyNeed(s);
            RaiseSatisfaction(n, satisfied);
        }
    }

    private void RaiseSatisfaction(Need need, bool satisfied)
    {
        if(MonsterSatisfied != null)
        {
            MonsterSatisfied.Invoke(need, satisfied);
        }
    }
}
