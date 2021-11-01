using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textes : MonoBehaviour
{
    void Awake()
    {
        EventAggregator.OnClick.Subscribe(ChangeText);
    }

    private void OnDestroy()
    {
        EventAggregator.OnClick.Unsubscribe(ChangeText);
    }

    void ChangeText(string text)
    {
        GetComponent<Text>().text = text;
    }
}