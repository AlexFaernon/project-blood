using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStatistics : MonoBehaviour
{
    public void NextScene()
    {
        switch (CurrentGameMode.GameMode)
        {
            case GameMode.MainMenu:
                throw new ArgumentException("not in game");
            case GameMode.Game:
                SceneManager.LoadScene("DayStart");
                break;
            case GameMode.Training:
                LoadMainMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Back()
    {
        switch (CurrentGameMode.GameMode)
        {
            case GameMode.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameMode.Game:
                SceneManager.LoadScene("Dayly statistics");
                break;
            case GameMode.Training:
                SceneManager.LoadScene("TrainingStatistics");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void LoadGlobalStatistics()
    {
        SceneManager.LoadScene("Statistics");
    }
    
    public void LoadMainMenu()
    {
        CurrentGameMode.GameMode = GameMode.MainMenu;
        SceneManager.LoadScene("MainMenu");
    }
}
