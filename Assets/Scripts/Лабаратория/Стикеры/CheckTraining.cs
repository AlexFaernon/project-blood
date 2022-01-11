using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckTraining : MonoBehaviour
{
    private Button button;

    public void OnClick()
    {
        BloodClass.ClearCurrentBloodSample();
        
        if (!BloodClass.UnknownBloodSamples.Any())
        {
            BloodClass.ClearBloodSamples();
            SceneManager.LoadScene("TrainingStatistics");
            return;
        }
        
        SceneManager.LoadScene("Lab");
    }
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    private void Update()
    {
        if (BloodClass.CurrentBloodSample is { ClassificationDone: true })
        {
            button.interactable = true;
        }
    }
}
