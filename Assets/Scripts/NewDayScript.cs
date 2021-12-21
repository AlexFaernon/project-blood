using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDayScript : MonoBehaviour
{
    public void StartNewDay()
    {
        //todo Resources.CreateFirstSamples();
        SceneManager.LoadScene("Shop");
    }
}
