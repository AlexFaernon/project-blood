using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadRecipes : MonoBehaviour
{
    private void Awake()
    {
        if (Recipes.Cocktails.Count > 0)
        {
            return;
        }

        var recipes = UnityEngine.Resources.Load<TextAsset>("Recipes").text;

        foreach (var recipe in recipes.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)) 
        {
            var splitRecipe = recipe.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var recipeName = splitRecipe[0];
            var description = splitRecipe[1];
            var blood = splitRecipe[2];
            var ingredients = splitRecipe[3];
            var parsedIngredients = new HashSet<Food.Ingredient>();
            foreach (var ingredient in ingredients.Split())
            {
                parsedIngredients.Add(ParseIngredient(ingredient));
            }

            Recipes.Cocktails[parsedIngredients] = GetCocktail(recipeName, description, blood.Split());
        }
    }

    private Food.Ingredient ParseIngredient(string ingredient)
    {
        if (ingredient.Contains(","))
        {
            var split = ingredient.Split(',');
            Enum.TryParse<Food.Fruits>(split[0], out var fruit);
            Enum.TryParse<Food.Condition>(split[1], out var condition);
            return new Food.Ingredient(fruit, condition);
        }
        
        Enum.TryParse<Food.Miscellaneous>(ingredient, out var miscellaneous);
        return new Food.Ingredient(miscellaneous);
    }

    private Food.Cocktail GetCocktail(string recipeName, string description, string[] blood)
    {
        Enum.TryParse<BloodGroup>(blood[0], out var bloodGroup);
        Enum.TryParse<Rh>(blood[1], out var rh);
        Enum.TryParse<BloodQuality>(blood[2], out var bloodQuality);

        return new Food.Cocktail(recipeName, description, bloodGroup, rh, bloodQuality);
    }
}
