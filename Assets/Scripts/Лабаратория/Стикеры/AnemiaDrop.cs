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
            ChangeSticker(BloodClass.CurrentBloodSample?.BloodQualitySticker);
        
        EventAggregator.BloodQualitySticker.Subscribe(ChangeSticker);
        if (GameMode.IsTraining)
        {
            EventAggregator.OnTrainingCheck.Subscribe(OnTrainingCheck);
        }
    }

    private void ChangeSticker(BloodQuality? bloodQuality)
    {
        BloodClass.CurrentBloodSample.BloodQualitySticker = bloodQuality;
        
        image.color = Color.white;
        switch (BloodClass.CurrentBloodSample.BloodQualitySticker)
        {
            case BloodQuality.Normal:
                image.sprite = spriteNormal;
                break;
            case BloodQuality.Anemia:
                image.sprite = spriteAnemia;
                break;
            case null:
                image.color = Color.clear;
                break;
        }
    }

    private void OnTrainingCheck()
    {
        if (BloodClass.CurrentBloodSample.BloodQuality == BloodClass.CurrentBloodSample.BloodQualitySticker)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
            EventAggregator.HighlightCorrectQualitySticker.Publish(BloodClass.CurrentBloodSample.BloodQuality);
        }
    }

    private void OnDestroy()
    {
        EventAggregator.BloodQualitySticker.Unsubscribe(ChangeSticker);
        if (GameMode.IsTraining)
        {
            EventAggregator.OnTrainingCheck.Unsubscribe(OnTrainingCheck);
        }
    }
}