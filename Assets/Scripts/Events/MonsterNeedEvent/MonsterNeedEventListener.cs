using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterNeedEventListener : MonoBehaviour
{
    public MonsterNeedEvent Event;
    public UnityEvent<MonsterNeeds> Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(MonsterNeeds monsterNeeds)
    { Response?.Invoke(monsterNeeds); }

}
