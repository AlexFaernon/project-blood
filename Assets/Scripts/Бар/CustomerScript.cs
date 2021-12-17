using System;
using TMPro;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text phrase;
    private Customer customer;
    private void Awake()
    {
        customer = CustomersClass.GetCurrentCustomer;
        if (customer == null)
        {
            gameObject.SetActive(false);
            return;
        }

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
