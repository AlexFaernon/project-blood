using System;
using UnityEngine;
using UnityEngine.UI;

public class AnemiaDrop : MonoBehaviour
{
    [SerializeField] private Sprite spriteNormal;
    [SerializeField] private Sprite spriteAnemia;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        
        if (BloodClass.CurrentBloodSample != null)
            ChangeSticker(BloodClass.CurrentBloodSample?.QualitySticker);
        
        EventAggregator.BloodQualitySticker.Subscribe(ChangeSticker);
    }

    private void ChangeSticker(BloodQuality? bloodQuality)
    {
        BloodClass.CurrentBloodSample.QualitySticker = bloodQuality;
        
        image.color = Color.white;
        switch (BloodClass.CurrentBloodSample.QualitySticker)
        {
            case BloodQuality.Normal:
                image.sprite = spriteNormal;
                break;
            case BloodQuality.Anemia:
                image.sprite = spriteAnemia;
                break;
            case null:
                image.color = new Color(0,0,0,0);
                break;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.BloodQualitySticker.Unsubscribe(ChangeSticker);
    }
}