using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSampleTablet : MonoBehaviour
{
    private void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
        }
    }
}
