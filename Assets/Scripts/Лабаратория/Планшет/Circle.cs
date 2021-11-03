using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private int number;
    private CircleContent content;
    void Awake()
    {
        number = int.Parse(name);
        if (TabletCircles.Circles[number] != null)
        {
            TabletCircles.Circles[number] = new CircleContent();
        }
        content = TabletCircles.Circles[number];
        EventAggregator.PlasmaDrop.Subscribe(OnPlasmaDrop);
        EventAggregator.BloodCellsDrop.Subscribe(OnBloodCellsDrop);
        EventAggregator.ErythrocyteDrop.Subscribe(OnErythrocyteDrop);
        EventAggregator.AntigenDrop.Subscribe(OnAntigenDrop);
    }

    private void OnPlasmaDrop()
    {
        content.ContainsPlasma = true;
    }

    private void OnBloodCellsDrop()
    {
        if (content.ContainsPlasma)
            content.ContainsPlasma = true;
    }

    private void OnErythrocyteDrop(Erythrocyte erythrocyte)
    {
        if (content.ContainsPlasma)
            content.Erythrocytes.Add(erythrocyte);
    }

    private void OnAntigenDrop(Antigen antigen)
    {
        if (content.ContainsPlasma)
            content.Antigens.Add(antigen);
    }

    private void OnDestroy()
    {
        EventAggregator.PlasmaDrop.Unsubscribe(OnPlasmaDrop);
        EventAggregator.BloodCellsDrop.Unsubscribe(OnBloodCellsDrop);
        EventAggregator.ErythrocyteDrop.Unsubscribe(OnErythrocyteDrop);
        EventAggregator.AntigenDrop.Unsubscribe(OnAntigenDrop);
    }
}
