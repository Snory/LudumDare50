using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewMonsterNeedEvent", menuName = "Events/MonsterNeedEvent", order = 1)]
public class MonsterNeedEvent : ScriptableObject
{

    private List<MonsterNeedEventListener> listeners =
   new List<MonsterNeedEventListener>();

    public void Raise(MonsterNeeds monsterNeeds)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(monsterNeeds);
    }

    public void RegisterListener(MonsterNeedEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(MonsterNeedEventListener listener)
    { listeners.Remove(listener); }
}
    
