using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewLevelPhaseEvent", menuName = "Events/LevelPhaseEvents", order = 1)]
public class LevelPhaseEvent : ScriptableObject
{
	private List<LevelPhaseEventListener> listeners =
	new List<LevelPhaseEventListener>();

	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised();
	}

	public void RegisterListener(LevelPhaseEventListener levelPhaseListener)
	{ listeners.Add(levelPhaseListener); }

	public void UnregisterListener(LevelPhaseEventListener levelPhaseListener)
	{ listeners.Remove(levelPhaseListener); }


}
