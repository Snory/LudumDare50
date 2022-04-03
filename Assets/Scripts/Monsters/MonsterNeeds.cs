using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class MonsterNeeds : MonoBehaviour
{

    [SerializeField]
    private MonsterNeedEvent _monsterSpawned;

    [SerializeField]
    private GlobalOneFloatEvent _updatedScore;

    [SerializeField]
    private SatisfierEvent _satisfierUsed;


    public UnityEvent<Need> CurrentNeedChanged;

    public UnityEvent Satisfied;

    public int NeedyLevel { get; set; }
    public List<NeedCategory> Needs;
    private List<MonsterNeedSatisfier> _currentNeeds;
    private int _indexOfCurrentNeed;
    private MonsterNeedSatisfier _currentMonsterNeedSatisfier;
    public bool Selected;


    private void Awake()
    {
        _currentNeeds = new List<MonsterNeedSatisfier>();
        NeedyLevel = 0;
        _indexOfCurrentNeed = -1;
        RaiseNeedyLevel();
        _monsterSpawned.Raise(this);
    }


    public void RaiseNeedyLevel()
    {
        NeedyLevel++;
    }

    public void GenerateCurrentNeeds()
    {
        _currentNeeds.Clear();

        for (int i = 0; i < NeedyLevel; i++)
        {
            Need n = Needs[i].GetNeed();
            Satisfier defaultSatisfier = Needs[i].DefaultSatisfier;
            _currentNeeds.Add(new MonsterNeedSatisfier(n, defaultSatisfier));
        }
        SetCurrentNeed(true);
    }

    public void SatisfyNeeds()
    {
        float deltaScore = 0;
        for (int i = 0; i < _currentNeeds.Count; i++)
        {
            Need n = _currentNeeds[i].Need;
            Satisfier s = _currentNeeds[i].Satisfier;
            bool satisfied = n.CanUseSatisfier(s);

            if (satisfied)
            {
                deltaScore += 100;
            } else
            {
                deltaScore -= 50;
            }
        }

        RaiseUpdateScore(deltaScore);
    }

    public void UseSatisfier(Satisfier satisfier)
    {

        if (Selected)
        {
            //check if satisfier can be used
            bool canUseSatisfier = _currentMonsterNeedSatisfier.Need.CanUseSatisfier(satisfier);

            if (!canUseSatisfier)
            {
                return;
            }
            _currentMonsterNeedSatisfier.Satisfier = satisfier;
            RaiseSatisfierUsed(satisfier);
            SetCurrentNeed(false);               
        }

    }

    private void SetCurrentNeed(bool reset)
    {
        if (reset)
        {
            _indexOfCurrentNeed = 0;
        } else if (_indexOfCurrentNeed < (NeedyLevel-1))
        {
            _indexOfCurrentNeed++;
        } else if ( _indexOfCurrentNeed >= (NeedyLevel - 1))
        {
            RaiseSatisfied();
            return;
        }

        _currentMonsterNeedSatisfier = _currentNeeds[_indexOfCurrentNeed];

        RaiseCurrentNeedChanged();
    }

    public void OnMonsterNeedCycle(MonsterNeeds monsterNeeds)
    {

        if(monsterNeeds != this)
        {
            return;
        };
        GenerateCurrentNeeds();
    }

    public void OnMonsterEvaluationCycle(MonsterNeeds monsterNeeds)
    {
        if (monsterNeeds != this)
        {
            return;
        }
        SatisfyNeeds();
        RaiseNeedyLevel();
    }

    public void RaiseUpdateScore(float deltaScore)
    {
        if(_updatedScore != null)
        {
            _updatedScore.Raise(deltaScore);
        }
    }

    public void RaiseCurrentNeedChanged()
    {
        if(CurrentNeedChanged != null)
        {
            CurrentNeedChanged.Invoke(_currentMonsterNeedSatisfier.Need);
        }
    }


    public void RaiseSatisfierUsed(Satisfier satisfier)
    {
        if (_satisfierUsed != null)
        {
            _satisfierUsed.Raise(satisfier);
        }
    }


    public void RaiseSatisfied()
    {
        if(Satisfied != null)
        {
            Satisfied.Invoke();
        }
    }








}
