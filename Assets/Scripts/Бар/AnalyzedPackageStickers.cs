using System;
using UnityEngine;
using UnityEngine.UI;

public class AnalyzedPackageStickers : MonoBehaviour
{
   [SerializeField] private Image bloodGroupSticker;
   [SerializeField] private Image rhSticker;
   [SerializeField] private Image qualitySticker;
   [SerializeField] private Sprite Zero;
   [SerializeField] private Sprite A;
   [SerializeField] private Sprite B;
   [SerializeField] private Sprite AB;
   [SerializeField] private Sprite Negative;
   [SerializeField] private Sprite Positive;
   [SerializeField] private Sprite Normal;
   [SerializeField] private Sprite Anemia;
   private BloodSample bloodSample;

   private void Awake()
   {
      bloodSample = bloodSample = BloodClass.GetAnalyzedSampleByNumber(name);
      if (bloodSample == null)
      {
         gameObject.SetActive(false);
         return;
      }
      
      SetBloodGroupSticker();
      SetRhSticker();
      SetQualitySticker();
   }

   private void SetBloodGroupSticker()
   {
      bloodGroupSticker.sprite = bloodSample.BloodGroup switch
      {
         BloodGroup.Zero => Zero,
         BloodGroup.A => A,
         BloodGroup.B => B,
         BloodGroup.AB => AB,
         _ => bloodGroupSticker.sprite
      };
   }
   
   private void SetRhSticker()
   {
      rhSticker.sprite = bloodSample.Rh switch
      {
         Rh.Negative => Negative,
         Rh.Positive => Positive,
         _ => bloodGroupSticker.sprite
      };
   }
   
   private void SetQualitySticker()
   {
      qualitySticker.sprite = bloodSample.BloodQuality switch
      {
         BloodQuality.Normal => Normal,
         BloodQuality.Anemia => Anemia,
         _ => bloodGroupSticker.sprite
      };
   }
}
