using System;
using UnityEngine;

public class GenerateDailyStatistics : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    
    private void Start()
    {
        DailyStatistics.SetEnumerator();
        for (var i = 0; i < DailyStatistics.Records.Count; i++)
        {
            Instantiate(prefab, transform);
        }
    }
}
