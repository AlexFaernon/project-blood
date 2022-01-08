using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] private GameObject confirmScreen;
    
    public void OnClickYes()
    {
        BloodClass.CurrentBloodSample.ClassificationDone = true;
        if (!GameMode.IsTraining)
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
        confirmScreen.SetActive(false);
    }
}
