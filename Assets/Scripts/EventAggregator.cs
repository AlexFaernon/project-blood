using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventAggregator
{
    public static Event<string> OnClick = new Event<string>();
    public static Event<GameObject> OnDrop = new Event<GameObject>();
    public static BasicEvent PlasmaDrop = new BasicEvent();
    public static BasicEvent BloodCellsDrop = new BasicEvent();
    public static Event<Erythrocyte> ErythrocyteDrop = new Event<Erythrocyte>();
    public static Event<Antigen> AntigenDrop = new Event<Antigen>();
    public static Event<BloodGroup?> BloodGroupSticker = new Event<BloodGroup?>();
    public static Event<Rh?> RhSticker = new Event<Rh?>();
    public static Event<BloodQuality?> BloodQualitySticker = new Event<BloodQuality?>();
    public static BasicEvent SampleDropOnCentrifuge = new BasicEvent();
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

public class BasicEvent
{
    private readonly List<Action> callbacks = new List<Action>();

    public void Subscribe(Action callback)
    {
        callbacks.Add(callback);
    }

    public void Publish()
    {
        foreach (var callback in callbacks)
        {
            callback();
        }
    }

    public void Unsubscribe(Action callback)
    {
        callbacks.Remove(callback);
    }
}