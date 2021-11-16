using System;
using UnityEngine;
using UnityEngine.UI;

public class RhDrop : MonoBehaviour
{
    [SerializeField] private Sprite spriteNegative;
    [SerializeField] private Sprite spritePositive;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        
        if (BloodClass.CurrentBloodSample != null)
            ChangeSticker(BloodClass.CurrentBloodSample.RhSticker);
        
        EventAggregator.RhSticker.Subscribe(ChangeSticker);
    }

    private void ChangeSticker(Rh? rh)
    {
        BloodClass.CurrentBloodSample.RhSticker = rh;
        
        image.color = Color.white;
        switch (BloodClass.CurrentBloodSample.RhSticker)
        {
            case Rh.Negative:
                image.sprite = spriteNegative;
                break;
            case Rh.Positive:
                image.sprite = spritePositive;
                break;
            case null:
                image.color = new Color(0,0,0,0);
                break;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.RhSticker.Unsubscribe(ChangeSticker);
    }
}