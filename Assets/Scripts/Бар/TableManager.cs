using System.Collections.Generic;

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
    private static readonly List<Food.Ingredient> IngredientsOnTable = new List<Food.Ingredient>();

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
        BloodClass.RemoveAnalyzedPackage(CurrentPackage);
        CurrentPackage = null;
        IsPackageInShaker = false;
    }
    
    public static Food.Ingredient GetIngredientByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < IngredientsOnTable.Count)
        {
            return IngredientsOnTable[number];
        }

        return null;
    }

    public static void RemoveIngredientByName(string name)
    {
        var number = int.Parse(name);
        IngredientsOnTable.RemoveAt(number);
    }
    
    public static void AddIngredient(Food.Miscellaneous miscellaneous)
    {
        IngredientsOnTable.Add(new Food.Ingredient(miscellaneous));
    }
    
    public static void AddIngredient(Food.Fruits fruit)
    {
        IngredientsOnTable.Add(new Food.Ingredient(fruit, Food.Condition.Fruit));
    }
}
