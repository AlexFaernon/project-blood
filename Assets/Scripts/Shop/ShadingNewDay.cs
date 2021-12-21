using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadingNewDay : MonoBehaviour
{
    public void OnClickYes()
    {
        Shop.ToggleIngredients = true;
        SaveDataScript.SaveShop();
        SaveDataScript.SaveBlood();
        SaveDataScript.SaveMoney();
        CustomersClass.CreateNewCustomers();
        SceneManager.LoadScene("Bar");
    }

    public void OnClickNo()
    {
        gameObject.SetActive(false);
    }
}
