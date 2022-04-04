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

    private IEnumerator StartTimer(MonsterNeedsCycleTime monsterCycleEvent, bool restart)
    {
        if (!restart)
        {
            RaiseMonsterCycleChanged(monsterCycleEvent.CycleType);
        }

        float actualSeconds = 0;
        while(actualSeconds < monsterCycleEvent.CycleTime)
        {
            RaiseTimerTicked(monsterCycleEvent.CycleTime, actualSeconds);
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
