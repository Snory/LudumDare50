using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterSpawnSpotEventListener : MonoBehaviour
{
    public MonsterSpawnSpotEvent Event;
    public UnityEvent<MonsterSpawnSpot> Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(MonsterSpawnSpot spawnSpot)
    { Response?.Invoke(spawnSpot); }
}
