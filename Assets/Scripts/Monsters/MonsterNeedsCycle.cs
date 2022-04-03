using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterNeedsCycle : MonoBehaviour
{
    private int _lastCycleIndex;
    public Monster MonsterType;
    public UnityEvent<float, float> TimerTicked;

    //deal with this direct reference later
    [SerializeField]
    private MonsterNeeds _monsterNeeds;
    
    private bool _gameOver;

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

    private IEnumerator StartTimer(MonsterNeedsCycleTime monsterNeedsCycleTime, bool restart)
    {
        if (!restart)
        {
            RaiseMonsterNeedsCycle(monsterNeedsCycleTime.CycleEvent);
        }

        float actualSeconds = 0;
        while(actualSeconds < monsterNeedsCycleTime.CycleTime)
        {
            RaiseTimerTicked(monsterNeedsCycleTime.CycleTime, actualSeconds);
            actualSeconds += 1;
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
        StopAllCoroutines();
        StartCycle(true);
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

    private void RaiseMonsterNeedsCycle(MonsterNeedEvent monsterNeedEvent)
    {
        if(monsterNeedEvent != null)
        {
            monsterNeedEvent.Raise(_monsterNeeds);
        }
    }

    public void GameOver()
    {
        StopAllCoroutines();
        _gameOver = true;
    }
   
}
