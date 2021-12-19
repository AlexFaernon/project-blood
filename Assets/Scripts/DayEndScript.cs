using UnityEngine;
using UnityEngine.SceneManagement;

public class DayEndScript : MonoBehaviour
{
    public void OnClick()
    {
        Resources.ResetSamples();
        Shop.ToggleIngredients = false;
        SceneManager.LoadScene("Scenes/DayStart");
    }
}
