using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu( fileName = "NewGlobal",menuName = "Events/GlobalEvents", order =1)]
public class GlobalEvent : ScriptableObject
{
	private List<GlogalEventListener> listeners =
		new List<GlogalEventListener>();

	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised();
	}

	public void RegisterListener(GlogalEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(GlogalEventListener listener)
	{ listeners.Remove(listener); }

}
