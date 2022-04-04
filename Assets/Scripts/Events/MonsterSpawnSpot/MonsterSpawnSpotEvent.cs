using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewMonsterSpawnSpotEvent", menuName = "Events/MonsterSpawnSpotEvent", order = 1)]
public class MonsterSpawnSpotEvent : ScriptableObject
{
    private List<MonsterSpawnSpotEventListener> listeners =
   new List<MonsterSpawnSpotEventListener>();

    public void Raise(MonsterSpawnSpot spawnSpot)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(spawnSpot);
    }

    public void RegisterListener(MonsterSpawnSpotEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(MonsterSpawnSpotEventListener listener)
    { listeners.Remove(listener); }
}
