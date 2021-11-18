using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Sprite oneBarSprite;
    [SerializeField] private Sprite twoBarsSprite;
    [SerializeField] private Sprite threeBarsSprite;
    private BloodSample currentBloodSample;
    private Image image;

    private void Awake()
    {
        currentBloodSample = BloodClass.CurrentBloodSample;
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (currentBloodSample == null)
        {
            return;
        }

        if (currentBloodSample.IsAnalyzed)
        {
            image.sprite = oneBarSprite;

            if (currentBloodSample.IsSeparated)
            {
                image.sprite = twoBarsSprite;

                if (F())
                {
                    image.sprite = threeBarsSprite;
                    // todo tablet check
                }
            }
        }
    }

    private bool F()
    {
        return false;
    }
}
