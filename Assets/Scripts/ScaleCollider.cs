using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCollider : MonoBehaviour
{
    private void Awake()
    {
        var fitter = GetComponent<AspectRatioFitter>().aspectRatio;
        var rectTransform = GetComponent<RectTransform>().rect;
        GetComponent<BoxCollider2D>().size = new Vector2(rectTransform.height * fitter, rectTransform.height);
    }
    
}
