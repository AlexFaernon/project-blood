using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickLab : MonoBehaviour
{
    [SerializeField] private GameObject close;
    [SerializeField] private GameObject open;
    
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
        SceneManager.LoadScene("Stickers");
    }
    
    public void LoadHemoanalyzer()
    {
        SceneManager.LoadScene("Hemoanalyzer");
    }

    public void LoadGuideBook()
    {
        SceneManager.LoadScene("GuideBook");
    }

    public void LoadBar()
    {
        SceneManager.LoadScene("Bar");
    }

    public void ClearTablet()
    {
        TabletCircles.ClearTablet();
    }

    public void CloseWindow()
    {
        close.SetActive(false);
    }

    public void OpenWindow()
    {
        open.SetActive(true);
    }
}
