using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    [SerializeField] private GameObject confirmScreen;
    
    public void OnClickYes()
    {
        BloodClass.CurrentBloodSample.ClassificationDone = true;
        SaveDataScript.SaveBlood();
        BloodClass.ClearCurrentBloodSample();
        SceneManager.LoadScene("Lab");
    }

    public void OnClickNo()
    {
        confirmScreen.SetActive(false);
    }
}
