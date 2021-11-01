using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickLab : MonoBehaviour
{
    public void LoadLab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void LoadCentrifuge()
    {
        SceneManager.LoadScene("Centrifuge");
    }
    
    public void LoadTablet()
    {
        SceneManager.LoadScene("Tablet");
    }
    
    public void LoadStickers()
    {
        throw new NotImplementedException();
    }
    
    public void LoadHemoanalyzer()
    {
        throw new NotImplementedException();
    }
}
