using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRecord : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_Text given;
    private Image image;
    private TrainingResult trainingResult;

    private void Awake()
    {
        trainingResult = TrainingStatistics.GetResult();
        result.text = trainingResult.Analyzed.ToString();
        given.text = trainingResult.Given.ToString();

        image = GetComponent<Image>();
        image.color = trainingResult.IsCorrect ? Color.green : Color.red;
    }
}
