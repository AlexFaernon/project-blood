using TMPro;
using UnityEngine;

public class StatisticCircle : MonoBehaviour
{
    [SerializeField] private BloodGroup bloodGroup;
    [SerializeField] private Rh rh;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        var all = GlobalStatistics.allAttempts[(int)bloodGroup, (int)rh];
        var successful = GlobalStatistics.successfulAttempts[(int)bloodGroup, (int)rh];
        if (successful == 0)
        {
            text.text = "0%";
            return;
        }
        text.text = $"{(int)((double)successful / all * 100)}%";
    }
}
