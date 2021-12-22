using System.Collections.Generic;

public static class TableManager
{
    //todo saved
    public static HashSet<Food.Ingredient> Shaker = new HashSet<Food.Ingredient>();
    
    public static BloodSample CurrentPackage;
    public static bool IsPackageInShaker;
    //todo save all
    public static Food.Cocktail CurrentCocktail;
    public static Food.Fruits? CurrentBoardFruit = null;
    public static bool IsPiecesActive;
    public static bool IsPeelActive;
    
    public static Food.Fruits? CurrentJuicerFruit = null;

    public static bool IsGlassActive;
    //todo save
    public static List<Food.Ingredient> ingredientsOnTable { get; private set; } = new List<Food.Ingredient>();

    public static int IngredientsCount => ingredientsOnTable.Count;

    public static void ClearCocktail()
    {
        CurrentCocktail = null;
        IsPackageInShaker = false;
    }

    public static void ClearShaker()
    {
        Shaker = new HashSet<Food.Ingredient>();
        SaveDataScript.SaveShaker();
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
        if (number < ingredientsOnTable.Count)
        {
            return ingredientsOnTable[number];
        }

        return null;
    }

    public static void RemoveIngredientByName(string name)
    {
        var number = int.Parse(name);
        ingredientsOnTable.RemoveAt(number);
        SaveDataScript.SaveIngredientsOnTable();
    }

    public static void AddIngredientToShaker(Food.Ingredient ingredient)
    {
        Shaker.Add(ingredient);
        SaveDataScript.SaveShaker();
    }

    public static void LoadIngredients(List<Food.Ingredient> ingredients)
    {
        ingredientsOnTable = ingredients;
    }
    
    public static void AddIngredient(Food.Miscellaneous miscellaneous)
    {
        ingredientsOnTable.Add(new Food.Ingredient(miscellaneous));
        SaveDataScript.SaveIngredientsOnTable();
    }
    
    public static void AddIngredient(Food.Fruits fruit)
    {
        ingredientsOnTable.Add(new Food.Ingredient(fruit, Food.Condition.Fruit));
        SaveDataScript.SaveIngredientsOnTable();
    }
}
