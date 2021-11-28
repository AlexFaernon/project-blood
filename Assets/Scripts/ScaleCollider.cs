using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleCollider : MonoBehaviour
{
    private void Awake()
    {
        var rectTransform = GetComponent<RectTransform>().rect;
        if (TryGetComponent(out AspectRatioFitter aspectRatioFitter))
        {
            var aspectRatio = aspectRatioFitter.aspectRatio;
            GetComponent<BoxCollider2D>().size = new Vector2(rectTransform.height * aspectRatio, rectTransform.height);
        }
        else
        {
            GetComponent<BoxCollider2D>().size = new Vector2(rectTransform.width, rectTransform.height);
        }
    }
    
}
