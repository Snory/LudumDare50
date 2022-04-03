using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalOneFloatEventListener : MonoBehaviour
{
    public GlobalOneFloatEvent Event;
    public UnityEvent<float> Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(float value)
    { Response?.Invoke(value); }
}

