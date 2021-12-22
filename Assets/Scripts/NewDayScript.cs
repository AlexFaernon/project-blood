using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDayScript : MonoBehaviour
{
    public void StartNewDay()
    {
        Resources.CreateFirstSamples();
        SceneManager.LoadScene("Shop");
    }
}
