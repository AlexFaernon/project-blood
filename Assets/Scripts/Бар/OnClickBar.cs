using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickBar : MonoBehaviour
{
    public void LoadLab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadRecipes()
    {
        throw new NotImplementedException();
    }

    public void LoadFridge()
    {
        SceneManager.LoadScene("Fridge");
    }

    public void LoadBar()
    {
        SceneManager.LoadScene("Bar");
    }

    public void LoadBoard()
    {
        SceneManager.LoadScene("Board");
    }
}
