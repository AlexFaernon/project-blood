using UnityEngine;
using UnityEngine.SceneManagement;

public class NewDayScript : MonoBehaviour
{
    public void StartNewDay()
    {
        SceneManager.LoadScene("Shop");
    }
}
