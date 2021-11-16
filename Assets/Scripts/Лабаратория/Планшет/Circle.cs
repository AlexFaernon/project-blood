using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
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
            image.color = new Color(255, 0 , 0, 1);
            return;
        }

        if (content.ContainsPlasma)
        {
            image.color = new Color(0, 0, 255, 1);
            return;
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
                if (content.Erythrocytes.Contains(Erythrocyte.B) ||
                    content.ContainsBloodCells && content.Antigens.Contains(Antigen.AntiA))
                {
                    return true;
                }
                break;
            case BloodGroup.B:
                if (content.Erythrocytes.Contains(Erythrocyte.A) ||
                    content.ContainsBloodCells && content.Antigens.Contains(Antigen.AntiB))
                {
                    return true;
                }
                break;
            case BloodGroup.AB:
                if (content.ContainsBloodCells &&
                    (content.Antigens.Contains(Antigen.AntiA) || content.Antigens.Contains(Antigen.AntiB)))
                {
                    return true;
                }
                break;
        }

        if (BloodClass.CurrentBloodSample.Rh == Rh.Positive && content.ContainsBloodCells &&
            content.Antigens.Contains(Antigen.AntiD))
        {
            return true;
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
        Debug.Log("plasma");
        ChangeImage();
    }

    private void OnBloodCellsDrop()
    {
        if (!isTriggered) return;
        
        if (content.ContainsPlasma)
            content.ContainsBloodCells = true;
        Debug.Log("bloodcells");
        ChangeImage();
    }

    private void OnErythrocyteDrop(Erythrocyte erythrocyte)
    {
        if (!isTriggered) return;
        
        if (content.ContainsPlasma)
            content.Erythrocytes.Add(erythrocyte);
        Debug.Log("eryth" + erythrocyte);
        ChangeImage();
    }

    private void OnAntigenDrop(Antigen antigen)
    {
        if (!isTriggered) return;
        
        if (content.ContainsPlasma)
            content.Antigens.Add(antigen);
        Debug.Log("antigen" + antigen);
        ChangeImage();
    }

    private void OnDestroy()
    {
        EventAggregator.PlasmaDrop.Unsubscribe(OnPlasmaDrop);
        EventAggregator.BloodCellsDrop.Unsubscribe(OnBloodCellsDrop);
        EventAggregator.ErythrocyteDrop.Unsubscribe(OnErythrocyteDrop);
        EventAggregator.AntigenDrop.Unsubscribe(OnAntigenDrop);
    }
}
