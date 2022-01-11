using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainingRecord : MonoBehaviour
{
    [SerializeField] private TMP_Text result;
    [SerializeField] private TMP_Text given;
    [SerializeField] private Sprite correctSprite;
    private Image image;
    private TrainingResult trainingResult;

    private void Awake()
    {
        trainingResult = TrainingStatistics.GetResult();
        result.text = trainingResult.Analyzed.ToString();
        given.text = trainingResult.Given.ToString();

        image = GetComponent<Image>();
        if (trainingResult.IsCorrect)
        {
            image.sprite = correctSprite;
        }
    }
}
