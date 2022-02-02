using System;
using UnityEngine;
using UnityEngine.UI;

public class PipetteScript : MonoBehaviour
{
    [SerializeField] private Image dropImage;
    
    [SerializeField] private Sprite pipetteAntiA;
    [SerializeField] private Sprite pipetteAntiB;
    [SerializeField] private Sprite pipetteAntiD;
    [SerializeField] private Sprite pipetteErythrocyte;
    [SerializeField] private Sprite pipettePlasma;
    [SerializeField] private Sprite pipetteBlood;
    [SerializeField] private Sprite dropAntiA;
    [SerializeField] private Sprite dropAntiB;
    [SerializeField] private Sprite dropAntiD;
    [SerializeField] private Sprite dropErythrocyte;
    [SerializeField] private Sprite dropPlasma;
    [SerializeField] private Sprite dropBlood;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        
        EventAggregator.PlasmaPickUp.Subscribe(OnPlasmaPickUp);
        EventAggregator.BloodCellsPickUp.Subscribe(OnBloodCellsPickUp);
        EventAggregator.ErythrocytePickUp.Subscribe(OnErythrocytePickUp);
        EventAggregator.AntigenPickUp.Subscribe(OnAntigenPickUp);
    }

    private void OnPlasmaPickUp()
    {
        image.sprite = pipettePlasma;
        dropImage.sprite = dropPlasma;
    }

    private void OnBloodCellsPickUp()
    {
        image.sprite = pipetteBlood;
        dropImage.sprite = dropBlood;
    }

    private void OnErythrocytePickUp(Erythrocyte erythrocyte)
    {
        image.sprite = pipetteErythrocyte;
        dropImage.sprite = dropErythrocyte;
    }

    private void OnAntigenPickUp(Antigen antigen)
    {
        switch (antigen)
        {
            case Antigen.AntiA:
                image.sprite = pipetteAntiA;
                dropImage.sprite = dropAntiA;
                break;
            case Antigen.AntiB:
                image.sprite = pipetteAntiB;
                dropImage.sprite = dropAntiB;
                break;
            case Antigen.AntiD:
                image.sprite = pipetteAntiD;
                dropImage.sprite = dropAntiD;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(antigen), antigen, null);
        }
    }

    private void OnDestroy()
    {
        EventAggregator.PlasmaPickUp.Unsubscribe(OnPlasmaPickUp);
        EventAggregator.BloodCellsPickUp.Unsubscribe(OnBloodCellsPickUp);
        EventAggregator.ErythrocytePickUp.Unsubscribe(OnErythrocytePickUp);
        EventAggregator.AntigenPickUp.Unsubscribe(OnAntigenPickUp);
    }
        
}
