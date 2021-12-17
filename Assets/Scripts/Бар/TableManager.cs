using System.Collections.Generic;
using UnityEngine;

public static class TableManager
{
    //todo save
    public static HashSet<Food.Ingredient> Shaker = new HashSet<Food.Ingredient>();
    
    public static BloodSample CurrentPackage;
    public static bool IsPackageInShaker;
    public static Food.Cocktail CurrentCocktail;
    
    public static Food.Fruits? CurrentBoardFruit = null;
    public static bool IsPiecesActive;
    public static bool IsPeelActive;
    
    public static Food.Fruits? CurrentJuicerFruit = null;

    public static bool IsGlassActive;
    //todo save
    private static readonly List<(Food.Ingredient, Vector2)> IngredientsOnTable = new List<(Food.Ingredient, Vector2)>();

    public static int IngredientsCount => IngredientsOnTable.Count;

    public static void ClearCocktail()
    {
        CurrentCocktail = null;
        IsPackageInShaker = false;
    }

    public static void ClearShaker()
    {
        Shaker = new HashSet<Food.Ingredient>();
    }

    public static void RemovePackage()
    {
        CurrentPackage = null;
        IsPackageInShaker = false;
    }
    
    public static Food.Ingredient GetIngredientByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < IngredientsOnTable.Count)
        {
            return IngredientsOnTable[number].Item1;
        }

        return null;
    }

    public static void RemoveIngredientByName(string name)
    {
        var number = int.Parse(name);
        IngredientsOnTable.RemoveAt(number);
    }

    public static Vector2 GetPositionByName(string name)
    {
        var number = int.Parse(name);
        return IngredientsOnTable[number].Item2;
    }
    
    public static void SetPositionByName(string name, Vector2 pos)
    {
        var number = int.Parse(name);
        IngredientsOnTable[number] = (IngredientsOnTable[number].Item1, pos);
    }
    
    public static void AddIngredient(Food.Miscellaneous miscellaneous)
    {
        IngredientsOnTable.Add((new Food.Ingredient(miscellaneous), Vector2.zero));
    }
    
    public static void AddIngredient(Food.Fruits fruit)
    {
        IngredientsOnTable.Add((new Food.Ingredient(fruit, Food.Condition.Fruit), Vector2.zero));
    }
}
