using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] Sprite AgglutinatedSprite;
    [SerializeField] Sprite FilledSprite;

    private int number;
    private CircleContent content;
    private bool isTriggered;
    private Image image;

    private void Awake()
    {
        number = int.Parse(name);
        if (TabletCircles.Circles[number] == null)
        {
            TabletCircles.Circles[number] = new CircleContent();
        }
        content = TabletCircles.Circles[number];
        image = GetComponent<Image>();
        EventAggregator.PlasmaDrop.Subscribe(OnPlasmaDrop);
        EventAggregator.BloodCellsDrop.Subscribe(OnBloodCellsDrop);
        EventAggregator.ErythrocyteDrop.Subscribe(OnErythrocyteDrop);
        EventAggregator.AntigenDrop.Subscribe(OnAntigenDrop);
        ChangeImage();
    }

    private void ChangeImage()
    {
        if (IsAgglutinated())
        {
            image.sprite = AgglutinatedSprite;
            image.color = new Color(255, 255 , 255, 1);
            return;
        }

        if (content.ContainsPlasma || content.ContainsBloodCells)
        {
            image.sprite = FilledSprite;
            image.color = new Color(255, 255, 255, 1);
        }
    }
    
    private bool IsAgglutinated()
    {
        if (BloodClass.CurrentBloodSample == null)
            return false;
        
        switch (BloodClass.CurrentBloodSample.BloodGroup)
        {
            case BloodGroup.Zero:
                if (content.Erythrocytes.Contains(Erythrocyte.A) || content.Erythrocytes.Contains(Erythrocyte.B))
                {
                    return true;
                }
                break;
            case BloodGroup.A:
                if (content.Erythrocytes.Contains(Erythrocyte.B) || content.Antigens.Contains(Antigen.AntiA))
                {
                    return true;
                }
                break;
            case BloodGroup.B:
                if (content.Erythrocytes.Contains(Erythrocyte.A) || content.Antigens.Contains(Antigen.AntiB))
                {
                    return true;
                }
                break;
            case BloodGroup.AB:
                if (content.Antigens.Contains(Antigen.AntiA) || content.Antigens.Contains(Antigen.AntiB))
                {
                    return true;
                }
                break;
        }

        if (content.Antigens.Contains(Antigen.AntiD))
        {
            TabletCircles.AntiDUsed = true;
            
            if (BloodClass.CurrentBloodSample.Rh == Rh.Positive)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }

    private void OnPlasmaDrop()
    {
        if (!isTriggered) return;
        
        content.ContainsPlasma = true;
        ChangeImage();
    }

    private void OnBloodCellsDrop()
    {
        if (!isTriggered) return;
        
        content.ContainsBloodCells = true;
        ChangeImage();
    }

    private void OnErythrocyteDrop(Erythrocyte erythrocyte)
    {
        if (!isTriggered) return;
        
        if (content.ContainsPlasma)
        {
            TryUseErythrocyte(erythrocyte);
            content.Erythrocytes.Add(erythrocyte);
        }
        ChangeImage();
    }

    private void OnAntigenDrop(Antigen antigen)
    {
        if (!isTriggered) return;
        
        if (content.ContainsBloodCells)
        {
            TryUseAntigen(antigen);
            content.Antigens.Add(antigen);
        }
        ChangeImage();
    }

    private void TryUseErythrocyte(Erythrocyte erythrocyte)
    {
        if (content.Erythrocytes.Count != 0 || content.Antigens.Count != 0) return;
        
        switch (erythrocyte)
        {
            case Erythrocyte.Zero:
                Debug.Log("0");
                TabletCircles.ZeroUsed = true;
                break;
            case Erythrocyte.A:
                Debug.Log("A");
                TabletCircles.AUsed = true;
                break;
            case Erythrocyte.B:
                Debug.Log("B");
                TabletCircles.BUsed = true;
                break;
        }
    }

    private void TryUseAntigen(Antigen antigen)
    {
        if (content.Erythrocytes.Count != 0 || content.Antigens.Count != 0) return;
        
        switch (antigen)
        {
            case Antigen.AntiA:
                Debug.Log("antiA");
                TabletCircles.AntiAUsed = true;
                break;
            case Antigen.AntiB:
                Debug.Log("antiB");
                TabletCircles.AntiBUsed = true;
                break;
            case Antigen.AntiD:
                Debug.Log("antiD");
                TabletCircles.AntiDUsed = true;
                break;
        }
    }
    private void OnDestroy()
    {
        EventAggregator.PlasmaDrop.Unsubscribe(OnPlasmaDrop);
        EventAggregator.BloodCellsDrop.Unsubscribe(OnBloodCellsDrop);
        EventAggregator.ErythrocyteDrop.Unsubscribe(OnErythrocyteDrop);
        EventAggregator.AntigenDrop.Unsubscribe(OnAntigenDrop);
    }
}
