using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] private GameObject confirmScreen;
    
    public void OnClickYes()
    {
        BloodClass.CurrentBloodSample.ClassificationDone = true;
        if (CurrentGameMode.GameMode == GameMode.Game)
        {
            PackageToFridge();
        }
        else
        {
            CheckOnTraining();
        }
    }

    public void OnClickNo()
    {
        confirmScreen.SetActive(false);
    }

    private void PackageToFridge()
    {
        SaveDataScript.SaveBlood();
        SceneManager.LoadScene("Lab");
    }

    private void CheckOnTraining()
    {
        EventAggregator.OnTrainingCheck.Publish();
        TrainingStatistics.AddResult(BloodClass.CurrentBloodSample);
        GlobalStatistics.AddAttempt(BloodClass.CurrentBloodSample, BloodClass.CurrentBloodSample.IsCorrectlyAnalyzed);
        confirmScreen.SetActive(false);
    }
}
