using UnityEngine;

public class GenerateTrainingStatistics : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        TrainingStatistics.SetEnumerator();
        for (var i = 0; i < TrainingStatistics.ResultsCount; i++)
        {
            Instantiate(prefab, transform);
        }
    }
}
