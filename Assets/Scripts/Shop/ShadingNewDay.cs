using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadingNewDay : MonoBehaviour
{
    public void OnClickYes()
    {
        Shop.ToggleIngredients = true;
        SceneManager.LoadScene("Bar");
    }

    public void OnClickNo()
    {
        gameObject.SetActive(false);
    }
}
