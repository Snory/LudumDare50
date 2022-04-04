using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class MonsterNeeds : MonoBehaviour
{

    [SerializeField]
    private MonsterNeedsCycleType _needCycleType, _evaluationCycleType, _sellCycleType;


    [SerializeField]
    private MonsterNeedEvent _monsterNeedsGenerated;

    public MonsterType MonsterType;

    [SerializeField]
    private GlobalOneFloatEvent _scoreUpdateRequest;

    [SerializeField]
    private GlobalEvent _monsterDestroyed;

    public UnityEvent<float> MonsterScored;
    public UnityEvent MonsterSold;

    [SerializeField]
    private SatisfierEvent _stockSatisfierUsed;
        
    public UnityEvent<Need> CurrentNeedChanged;

    public UnityEvent Satisfied, UsedSatisfier;
        
    public int NeedyLevel { get; set; }
    private List<MonsterNeedSatisfier> _currentNeeds;
    private int _indexOfCurrentNeed;
    private MonsterNeedSatisfier _currentMonsterNeedSatisfier;

    private bool _selected, _sold, _canUseNeed;


    private float _maximumSatisfierLevelGeneration, _minimumSellLevel, _sellPricePerLevel;

    public void Init()
    {
        _currentNeeds = new List<MonsterNeedSatisfier>();
        NeedyLevel = 0;
        _indexOfCurrentNeed = -1;
        _maximumSatisfierLevelGeneration = MonsterType.MaximumStockGeneration;
        _minimumSellLevel = MonsterType.MinimumSellLevel;
        _sellPricePerLevel = MonsterType.SellValuePerLevel;
        RaiseNeedyLevel();
    }


    public void RaiseNeedyLevel()
    {
        if ((NeedyLevel + 1) > MonsterType.Needs.Count)
        {
            return;
        }

        NeedyLevel++;
    }

    public void GenerateCurrentNeeds()
    {
        _currentNeeds.Clear();

        for (int i = 0; i < NeedyLevel; i++)
        {
            Need n = MonsterType.Needs[i].GetNeed();
            Satisfier defaultSatisfier = MonsterType.Needs[i].DefaultSatisfier;
            _currentNeeds.Add(new MonsterNeedSatisfier(n, defaultSatisfier, defaultSatisfier));
        }

        if(NeedyLevel < _maximumSatisfierLevelGeneration)
        {
            RaiseMonsterNeedsGenerated();
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
                deltaScore += n.NeedScoreGain;
            } else
            {
                deltaScore -= n.NeedScorePenalty;
            }
        }

        RaiseUpdateScore(deltaScore);
    }

    public void UseStockSatisfier(Satisfier satisfier)
    {

        if (_selected && _canUseNeed)
        {
            if(_currentMonsterNeedSatisfier == null)
            {
                return;
            }
            //check if satisfier can be used
            bool canUseSatisfier = _currentMonsterNeedSatisfier.Need.CanUseSatisfier(satisfier);

            if (!canUseSatisfier)
            {
                return;
            }
            _currentMonsterNeedSatisfier.Satisfier = satisfier;
            RaiseStockSatisfierUsed(satisfier);
            SetCurrentNeed(false);               
        }

    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
    }

    private void SetCurrentNeed(bool reset)
    {
        if (reset)
        {
            _indexOfCurrentNeed = GetClosestNotSatisfiedIndex(0);
        } else if (_indexOfCurrentNeed + 1 < _currentNeeds.Count)
        {
            _indexOfCurrentNeed++;
        } else 
        {
            _indexOfCurrentNeed = GetClosestNotSatisfiedIndex(0);

            if(_indexOfCurrentNeed >= _currentNeeds.Count)
            {
                _currentMonsterNeedSatisfier = null;
                RaiseSatisfied();
                return;
            }

        }

        _currentMonsterNeedSatisfier = _currentNeeds[_indexOfCurrentNeed];

        RaiseCurrentNeedChanged();
    }

    private int GetClosestNotSatisfiedIndex(int indexFrom)
    {
        int index = _currentNeeds.Count + 1;
        for (int i = indexFrom; i < _currentNeeds.Count; i++)
        {
            if (_currentNeeds[i].IsDefaultSatisfierUsed())
            {
                index = indexFrom;
                return index;
            }
        }
        return index;
    }

    public void OnInncerCycleChanged(MonsterNeedsCycleType cycleType)
    {
        if (_sold) return;

        if(cycleType == _needCycleType)
        {
            GenerateCurrentNeeds();
            _canUseNeed = true;

        } else if (cycleType == _evaluationCycleType)
        {
            SatisfyNeeds();
            RaiseNeedyLevel();
            _canUseNeed = false;
        } 
    }

    public void OnMonsterRequestSell()
    {
        if(NeedyLevel >= _minimumSellLevel)
        {
            _sold = true;
            RaiseUpdateScore(NeedyLevel * _sellPricePerLevel);
            RaiseMonsterSold();
            RaiseMonsterDestroyed();
        }

    }

    public void RaiseUsedSatisfier()
    {
        if (UsedSatisfier != null)
        {
            UsedSatisfier.Invoke();
        }
    }

    public void RaiseMonsterSold()
    {
        if(MonsterSold != null)
        {
            MonsterSold.Invoke();
        }
    }

    public void RaiseMonsterDestroyed()
    {
        if(_monsterDestroyed != null)
        {
            _monsterDestroyed.Raise();
        }
        Destroy(this.gameObject);
    }


    public void RaiseUpdateScore(float deltaScore)
    {
        if(_scoreUpdateRequest != null)
        {
            _scoreUpdateRequest.Raise(deltaScore);
        }

        if(MonsterScored != null)
        {
            MonsterScored.Invoke(deltaScore);
        }
    }

    public void RaiseCurrentNeedChanged()
    {
        if(CurrentNeedChanged != null)
        {
            CurrentNeedChanged.Invoke(_currentMonsterNeedSatisfier.Need);
        }
    }


    public void RaiseStockSatisfierUsed(Satisfier satisfier)
    {
        if (_stockSatisfierUsed != null)
        {
            _stockSatisfierUsed.Raise(satisfier);
        }
    }

    private void RaiseMonsterNeedsGenerated()
    {
        if (_monsterNeedsGenerated != null)
        {
            _monsterNeedsGenerated.Raise(this);
        }
    }

    public void RaiseSatisfied()
    {
        if (Satisfied != null)
        {
            Satisfied.Invoke();
        }
    }

    public void OnSkipCurrentNeed()
    {
        SetCurrentNeed(false);
    }




}
