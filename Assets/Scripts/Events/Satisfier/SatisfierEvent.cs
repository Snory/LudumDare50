using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSatisfierEvent", menuName = "Events/SatisfierEvent", order = 1)]
public class SatisfierEvent : ScriptableObject
{
    private List<SatisfierEventListener> listeners =
   new List<SatisfierEventListener>();

    public void Raise(Satisfier satisfier)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(satisfier);
    }

    public void RegisterListener(SatisfierEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(SatisfierEventListener listener)
    { listeners.Remove(listener); }
}
