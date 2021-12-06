using System.Collections.Generic;
using UnityEngine;

public class BarEvents : MonoBehaviour
{
    private void Awake()
    {
        EventAggregator.OnFruitDrop.Subscribe(TableManager.AddIngredient);
        EventAggregator.OnMiscDrop.Subscribe(TableManager.AddIngredient);
    }

    private void OnDestroy()
    {
        EventAggregator.OnFruitDrop.Unsubscribe(TableManager.AddIngredient);
        EventAggregator.OnMiscDrop.Unsubscribe(TableManager.AddIngredient);
    }
}

public static class TableManager
{
    //todo save
    public static readonly List<Food.Ingredient> Ingredients = new List<Food.Ingredient>();

    public static Food.Ingredient GetIngredientByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < Ingredients.Count)
        {
            return Ingredients[number];
        }

        return null;
    }
    
    public static void AddIngredient(Food.Miscellaneous miscellaneous)
    {
        Ingredients.Add(new Food.Ingredient(miscellaneous));
    }
    
    public static void AddIngredient(Food.Fruits fruit)
    {
        Ingredients.Add(new Food.Ingredient(fruit, Food.Condition.Fruit));
    }
}
