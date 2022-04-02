using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MonsterNeeds : MonoBehaviour
{

    [SerializeField]
    private MonsterNeedEvent _monsterSpawned;

    [SerializeField]
    private SatisfierEvent _satisfierUsed;
    //variable list of category needs per level
    public int NeedyLevel { get; set; }
    public List<NeedCategory> Needs;
    //variable list of actual needs for given level
    private List<MonsterNeedSatisfier> _actualNeeds;
    //variable list of actual sources for given level
    //variable to store level index
    private int _indexOfCurrentNeed;

    public bool Selected;

    private void Start()
    {
        _actualNeeds = new List<MonsterNeedSatisfier>();
        NeedyLevel = 0;
        _indexOfCurrentNeed = 0;
        //raise first need level
        RaiseNeedyLevel();
        RaiseNeedyLevel();
        RaiseNeedyLevel();
        //raise monster spawned
        _monsterSpawned.Raise(this);        
        //generated needs
        GenerateActualNeeds();
    }

    public void RaiseNeedyLevel()
    {
        NeedyLevel++;
    }

    public void GenerateActualNeeds()
    {
        _actualNeeds.Clear();

        for (int i = 0; i < NeedyLevel; i++)
        {
            Need n = Needs[i].GetNeed();
            Satisfier defaultSatisfier = Needs[i].DefaultSatisfier;
            _actualNeeds.Add(new MonsterNeedSatisfier(n, defaultSatisfier));
        }

        _indexOfCurrentNeed = 0;
    }

    public void SatisfyNeeds()
    {
        for (int i = 0; i < _actualNeeds.Count; i++)
        {
            Need n = _actualNeeds[i].Need;
            Satisfier s = _actualNeeds[i].Satisfier;
            bool satisfied = n.CanUseSatisfier(s);

            Debug.Log("Need satisfaction: " + satisfied);
        }
    }

    public void UseSatisfier(Satisfier satisfier)
    {
        if (Selected)
        {
            //check if satisfier can be used
            bool canUseSatisfier = _actualNeeds[_indexOfCurrentNeed].Need.CanUseSatisfier(satisfier);
            Debug.Log("Requested usage of satisfier and can use: " + canUseSatisfier);

            if (!canUseSatisfier)
            {
                return;
            }
            _actualNeeds[_indexOfCurrentNeed].Satisfier = satisfier;
            RaiseSatisfierUsed(satisfier);

            if(_indexOfCurrentNeed < NeedyLevel)
            {
                _indexOfCurrentNeed++;
            }
        }
    }

    public void RaiseSatisfierUsed(Satisfier satisfier)
    {
        if(_satisfierUsed != null)
        {
            _satisfierUsed.Raise(satisfier);
        }
    }








}
