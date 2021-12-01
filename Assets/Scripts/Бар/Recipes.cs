using System.Collections.Generic;

public static class Recipes
{
    public static readonly Dictionary<HashSet<Food.Ingredient>, Food.Cocktail> Cocktails =
        new Dictionary<HashSet<Food.Ingredient>, Food.Cocktail>();
}
