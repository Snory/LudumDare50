using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewLevelPhaseEvent", menuName = "LevelPhaseEvents", order = 1)]
public class LevelPhaseEvent : ScriptableObject
{
	private List<LevelPhaseListener> listeners =
	new List<LevelPhaseListener>();

	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised();
	}

	public void RegisterListener(LevelPhaseListener levelPhaseListener)
	{ listeners.Add(levelPhaseListener); }

	public void UnregisterListener(LevelPhaseListener levelPhaseListener)
	{ listeners.Remove(levelPhaseListener); }


}
