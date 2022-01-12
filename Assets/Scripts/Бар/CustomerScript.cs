using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text phrase;
    private Customer customer;
    private void Awake()
    {
        customer = CustomersClass.CurrentCustomer;
        if (customer == null)
        {
            SceneManager.LoadScene("DayEnd");
            return;
        }

        GetComponent<Image>().sprite = customer.Avatar;
        EventAggregator.SellCocktail.Subscribe(SellCocktail);
        phrase.text = customer.Order;
    }

    private void SellCocktail(Food.Cocktail cocktail)
    {
        var stars = customer.CheckCocktail(cocktail);
        Debug.Log(stars.ToString());
    }

    private void OnDestroy()
    {
        EventAggregator.SellCocktail.Unsubscribe(SellCocktail);
    }
}
