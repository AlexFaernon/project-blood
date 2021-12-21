using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickShop : MonoBehaviour
{
    [SerializeField] private GameObject newDayShading;
    public void LoadBar()
    {
        if (!Shop.ToggleIngredients)
        {
            newDayShading.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Bar");
        }
    }
}

public static class Shop
{
    //todo saved
    public static bool ToggleIngredients;
}
