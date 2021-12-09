using System;
using System.Collections.Generic;
using UnityEngine;

public static class TableManager
{
    public static Food.Fruits? CurrentBoardFruit = null;
    public static Food.Fruits? CurrentJuicerFruit = null;
    //todo save
    private static readonly List<(Food.Ingredient, Vector2)> Ingredients = new List<(Food.Ingredient, Vector2)>();

    public static Food.Ingredient GetIngredientByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < Ingredients.Count)
        {
            return Ingredients[number].Item1;
        }

        return null;
    }

    public static void RemoveIngredientByName(string name)
    {
        var number = int.Parse(name);
        Ingredients.RemoveAt(number);
    }

    public static Vector2 GetPositionByName(string name)
    {
        var number = int.Parse(name);
        return Ingredients[number].Item2;
    }
    
    public static void SetPositionByName(string name, Vector2 pos)
    {
        var number = int.Parse(name);
        Ingredients[number] = (Ingredients[number].Item1, pos);
    }
    
    public static void AddIngredient(Food.Miscellaneous miscellaneous)
    {
        Ingredients.Add((new Food.Ingredient(miscellaneous), Vector2.zero));
    }
    
    public static void AddIngredient(Food.Fruits fruit)
    {
        Ingredients.Add((new Food.Ingredient(fruit, Food.Condition.Fruit), Vector2.zero));
    }
}
