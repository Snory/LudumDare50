using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterActions : MonoBehaviour
{
    public UnityEvent MonsterSellRequest;

    public UnityEvent SkipedCurrentRequest;

    public UnityEvent SkippedEvaluationPhase;

    [SerializeField]
    private MonsterNeedsCycleType _needCycleType, _evaluationCycleType, _sellCycleType;

    private bool _canSold, _canMoveToNext, _canSkip, _selected;

    public void OnClick()
    {
        if (!_selected) return;

        if (_canSold)
        {
            RaiseMonsterSellRequest();
        }

        if (_canMoveToNext)
        {
            RaiseSkipCurrentRequest();
        }

        if (_canSkip)
        {
            RaiseSkipEvaluationPhase();
        }
    }

    public void OnInncerCycleChanged(MonsterNeedsCycleType cycleType)
    {
        
        if (cycleType == _sellCycleType)
        {
            _canSold = true;

        }
        else 
        {
            _canSold = false;
        }

        if(cycleType == _needCycleType)
        {
            _canMoveToNext = true;
        } else
        {
            _canMoveToNext = false;
        }

        if (cycleType == _evaluationCycleType)
        {
            _canSkip = true;
        }
        else
        {
            _canSkip = false;
        }
    }


    public void RaiseMonsterSellRequest()
    {
        if(MonsterSellRequest != null)
        {
            MonsterSellRequest.Invoke();
        }
    }

    public void RaiseSkipCurrentRequest()
    {
        if(SkipedCurrentRequest != null)
        {
            SkipedCurrentRequest.Invoke();
        }
    }

    public void RaiseSkipEvaluationPhase()
    {
        if (SkippedEvaluationPhase != null)
        {
            SkippedEvaluationPhase.Invoke();
        }
    }

    public void OnSelectedChanged(bool selected)
    {
        _selected = selected;
    }


}

