using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSampleTablet : MonoBehaviour
{
    [SerializeField] private Sprite notSeparatedSprite;
    private void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
            return;
        }

        if (!BloodClass.CurrentBloodSample.IsSeparated)
        {
            GetComponent<Image>().sprite = notSeparatedSprite;
            foreach (Transform childTransform in transform)
            {
                childTransform.gameObject.SetActive(false);
            }
        }
    }
}
