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
        throw new NotImplementedException();
    }

    public void LoadRecipes()
    {
        throw new NotImplementedException();
    }
}
