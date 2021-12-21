using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        throw new NotImplementedException();
    }
}
