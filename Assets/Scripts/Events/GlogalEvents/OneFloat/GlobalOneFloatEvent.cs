using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewGlobalOneFloat", menuName = "Events/GlobalEvents/OneFloat", order = 2)]
public class GlobalOneFloatEvent : ScriptableObject
{
	private List<GlobalOneFloatEventListener> listeners =
		new List<GlobalOneFloatEventListener>();

	public void Raise(float value)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(value);
	}

	public void RegisterListener(GlobalOneFloatEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(GlobalOneFloatEventListener listener)
	{ listeners.Remove(listener); }
}
