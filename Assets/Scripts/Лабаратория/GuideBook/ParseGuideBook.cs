using System;
using System.Collections.Generic;
using UnityEngine;

public class ParseGuideBook : MonoBehaviour
{
    private void Awake()
    {
        var text = UnityEngine.Resources.Load<TextAsset>("GuideBookVol1-2").text;
        GuideBookText.Pages = text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
