using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStatistics : MonoBehaviour
{
    public void LoadNewDay()
    {
        SceneManager.LoadScene("DayStart");
    }
    public void LoadDailyStatistic()
    {
        SceneManager.LoadScene("Dayly statistics");
    }

    public void LoadGlobalStatistics()
    {
        SceneManager.LoadScene("Statistics");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
