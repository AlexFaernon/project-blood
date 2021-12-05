using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickMainMenu : MonoBehaviour
{
    public void LoadNewDay()
    {
        SceneManager.LoadScene("DayStart");
    }

    public void LoadStatistics()
    {
        SceneManager.LoadScene("Statistics");
    }
    public void LoadTraining()
    {
        throw new NotImplementedException();
    }
}
