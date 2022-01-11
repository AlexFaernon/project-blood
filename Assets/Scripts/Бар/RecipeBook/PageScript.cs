using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageScript : MonoBehaviour
{
    [SerializeField] private PageSide pageSide;
    [SerializeField] private TMP_Text cocktailName;
    [SerializeField] private TMP_Text recipe;
    [SerializeField] private TMP_Text blood;
    [SerializeField] private TMP_Text order;
    private Food.Cocktail cocktail;

    private Dictionary<string, string> Translate = new Dictionary<string, string>
    {
        {"Apple", "яблока"},
        {"Lemon", "лимона"},
        {"Pineapple", "ананаса"},
        {"Lime", "лайма"},
        {"Celery", "сельдерея"},
        {"Orange", "апельсина"},
        {"Pepper", "Перец"},
        {"Coffee", "Кофе"},
        {"Honey", "Мёд"},
        {"Carnation", "Корица"},
        {"Peel", "Кожура"},
        {"Pieces", "Кусочки"},
        {"Juice", "Сок"},
        {"Ice", "Лёд"}
    };

    private void Awake()
    {
        order.text = CustomersClass.CurrentCustomer.Order;
        cocktail = PagesManager.GetPage(pageSide);

        cocktailName.text = cocktail.Name;
        recipe.text = GetIngredients();
        blood.text = cocktail.BloodSample.ToString();
    }

    private string GetIngredients()
    {
        var ingredients = cocktail.Ingredients;
        var result = new List<string>();
        foreach (var ingredient in ingredients)
        {
            if (ingredient.Fruit != null)
            {
                result.Add($"{Translate[ingredient.Condition.ToString()]} {Translate[ingredient.Fruit.ToString()]}");
            }
            else
            {
                result.Add(Translate[ingredient.Miscellaneous.ToString()]);
            }
        }

        return string.Join("\n", result);
    }

    public void OnClick()
    {
        PagesManager.ChangePage(pageSide);
        SceneManager.LoadScene("RecipeBook");
    }
}
