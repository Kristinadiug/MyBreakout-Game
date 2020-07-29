using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static Dictionary<EventName, List<EventInvoker>> invokers = new Dictionary<EventName, List<EventInvoker>>();
    static Dictionary<EventName, List<UnityAction<float>>> listeners = new Dictionary<EventName, List<UnityAction<float>>>();

    public static void Initialize()
    {
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if(!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<EventInvoker>());
                listeners.Add(name, new List<UnityAction<float>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    public static void AddInvoker(EventName eventName, EventInvoker invoker)
    {
        invokers[eventName].Add(invoker);
        foreach (UnityAction<float> listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
    }

    public static void AddListener(EventName eventName, UnityAction<float> listener)
    {
        listeners[eventName].Add(listener);
        foreach(EventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
    }

    public static void RemoveInvoker(EventName eventName, EventInvoker invoker)
    {
        invokers[eventName].Remove(invoker);
    }

    public static void RemoveListener(EventName eventName, UnityAction<float> listener)
    {
        listeners[eventName].Remove(listener);
    }
}
