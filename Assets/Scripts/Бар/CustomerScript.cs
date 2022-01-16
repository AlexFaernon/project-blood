using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text phrase;
    [SerializeField] private GameObject bubble;
    private Image avatar;
    private Customer customer;
    private void Awake()
    {
        customer = CustomersClass.CurrentCustomer;
        if (customer == null)
        {
            SceneManager.LoadScene("DayEnd");
            return;
        }

        avatar = GetComponent<Image>();
        avatar.sprite = customer.NormalAvatar;
        EventAggregator.SellCocktail.Subscribe(SellCocktail);
        phrase.text = customer.Order;
    }

    private void SellCocktail(Food.Cocktail cocktail)
    {
        var stars = customer.CheckCocktail(cocktail);
        if (stars == OrderStars.NoStars)
        {
            avatar.sprite = customer.AngryAvatar;
        }
        else if (stars == OrderStars.TwoStars || stars == OrderStars.ThreeStars)
        {
            avatar.sprite = customer.HappyAvatar;
        }
        bubble.SetActive(false);
        
        Debug.Log(stars.ToString());
    }

    private void OnDestroy()
    {
        EventAggregator.SellCocktail.Unsubscribe(SellCocktail);
    }
}
