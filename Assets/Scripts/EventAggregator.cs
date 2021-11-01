using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventAggregator
{
    public static Event<string> OnClick = new Event<string>();
    public static Event<GameObject> OnDrop = new Event<GameObject>();
}

public class Event<T>
{
    private readonly List<Action<T>> callbacks = new List<Action<T>>();

    public void Subscribe(Action<T> callback)
    {
        callbacks.Add(callback);
    }

    public void Publish(T obj)
    {
        foreach (var callback in callbacks)
        {
            callback(obj);
        }
    }

    public void Unsubscribe(Action<T> callback)
    {
        callbacks.Remove(callback);
    }
}