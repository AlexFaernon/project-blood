using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventAggregator
{
    public static readonly Event<GameObject> OnDrop = new Event<GameObject>();
    public static readonly BasicEvent PlasmaDrop = new BasicEvent();
    public static readonly BasicEvent BloodCellsDrop = new BasicEvent();
    public static readonly Event<Erythrocyte> ErythrocyteDrop = new Event<Erythrocyte>();
    public static readonly Event<Antigen> AntigenDrop = new Event<Antigen>();
    public static readonly Event<BloodGroup?> BloodGroupSticker = new Event<BloodGroup?>();
    public static readonly Event<Rh?> RhSticker = new Event<Rh?>();
    public static readonly Event<BloodQuality?> BloodQualitySticker = new Event<BloodQuality?>();
    public static readonly BasicEvent SampleDropOnCentrifuge = new BasicEvent();
    public static readonly Event<Food.Fruits> OnFruitDrop = new Event<Food.Fruits>();
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