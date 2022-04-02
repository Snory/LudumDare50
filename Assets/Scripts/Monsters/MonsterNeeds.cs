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

    private List<Need> _actualNeeds;
    //variable list of actual sources for given level
    //variable to store level index



    private void Start()
    {
        _actualNeeds = new List<Need>();
        GenerateActualNeeds();
    }

    public void GenerateActualNeeds()
    {
        _actualNeeds.Clear();

        for (int i = 0; i < _levelOfNeeds; i++)
        {
            Need n = Needs[i].GenerateNeed();
            Debug.Log(n.GetType());
            _actualNeeds.Add(n);
        }
    }

    public void SatisfyNeeds()
    {

        for (int i = 0; i < _actualNeeds.Count; i++)
        {
            Need n = _actualNeeds[i];
            bool satisfied = n.SatisfyNeed();

            RaiseSatisfaction(n, satisfied);
            
            //raise whatever this pet was or was not satisfied
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
