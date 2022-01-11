using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class OnClickMainMenu : MonoBehaviour
{
    public void GameStart()
    {
        CurrentGameMode.GameMode = GameMode.Game;
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
        CurrentGameMode.GameMode = GameMode.Training;
        var random = new Random();
        
        for (var i = 0; i < 2; i++)
        {
            BloodClass.GenerateRandomSample(random);
        }

        SceneManager.LoadScene("Lab");
    }
}
