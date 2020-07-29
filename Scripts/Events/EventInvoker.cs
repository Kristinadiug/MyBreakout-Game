using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    protected Dictionary<EventName, UnityEvent<float>> unityEvents = new Dictionary<EventName, UnityEvent<float>>();

    public void Awake()
    {
        foreach(EventName name in Enum.GetValues(typeof(EventName)))
        {
            unityEvents.Add(name, new EffectActivated());
        }
    }

    public void AddListener(EventName eventName, UnityAction<float> listener)
    {
        if(unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(listener);
        }
        
    }

    public void InvokeEvent(EventName name, float value)
    {
        unityEvents[name].Invoke(value);
    }
}
