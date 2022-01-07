using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class OnClickMainMenu : MonoBehaviour
{
    public void GameStart()
    {
        LoadDataScript.LoadAll();
        if (Shop.ToggleIngredients)
        {
            SceneManager.LoadScene("Bar");
        }
        else
        {
            SceneManager.LoadScene("DayStart");
        }
    }

    public void LoadStatistics()
    {
        SceneManager.LoadScene("Statistics");
    }
    public void LoadTraining()
    {
        var random = new Random();
        
        for (var i = 0; i < 5; i++)
        {
            BloodClass.GenerateRandomSample(random);
        }

        GameMode.IsTraining = true;

        SceneManager.LoadScene("Lab");
    }
}
