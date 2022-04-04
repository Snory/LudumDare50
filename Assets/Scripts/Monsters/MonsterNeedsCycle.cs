using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterNeedsCycle : MonoBehaviour
{
    private int _lastCycleIndex;
    public MonsterType MonsterType;
    public UnityEvent<float, float> TimerTicked;

    public UnityEvent<MonsterNeedsCycleType> MonsterCycleChanged;
    
    private bool _gameOver;

    private float _innerTime;

    private void Awake()
    {
        _lastCycleIndex = 0;
        _gameOver = false;
    }

    private void Start()
    {
        StartCycle(false);
    }

    public void StartCycle(bool restart)
    {
        if (MonsterType.MonsterNeedCycleTimes.Count == 0)
        {
            Debug.LogError("[MonsterNeedsCycle]: EmptyMonster cycle");
        }

        StartCoroutine(StartTimer(MonsterType.MonsterNeedCycleTimes[_lastCycleIndex], restart));
    }

    private IEnumerator StartTimer(MonsterNeedsCycleTime monsterCycleEvent, bool restart)
    {
        if (restart == false)
        {
            RaiseMonsterCycleChanged(monsterCycleEvent.CycleType);
        }

        SetInnerTime(0);
        while(_innerTime < monsterCycleEvent.CycleTime)
        {
            RaiseTimerTicked(monsterCycleEvent.CycleTime, _innerTime);
            SetInnerTime(_innerTime + 1);
            if (_gameOver)
            {
                break;
            }
            yield return new WaitForSeconds(1);
        }
        NextCycle();
    }

    public void OnSatisfierUsed()
    {
        SetInnerTime(_innerTime - 1);
    }

    private void SetInnerTime(float newTime)
    {
        if(newTime < 0)
        {
            _innerTime = 0;
        } else
        {
            _innerTime = newTime;
        }
    }

    public void NextCycle()
    {
        StopAllCoroutines();

        if (_gameOver) return;

        if ((_lastCycleIndex + 1) < MonsterType.MonsterNeedCycleTimes.Count)
        {
            _lastCycleIndex++;
        }
        else
        {
            _lastCycleIndex = 0;
        }

        StartCycle(false);
    }

    private void RaiseTimerTicked(float cycleTime, float currentTime)
    {
        if(TimerTicked != null)
        {
            TimerTicked.Invoke(cycleTime, currentTime);
        }
    }

    private void RaiseMonsterCycleChanged(MonsterNeedsCycleType cycleType)
    {
        if(MonsterCycleChanged != null)
        {
            MonsterCycleChanged.Invoke(cycleType);
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
        _gameOver = true;
    }
   
}
