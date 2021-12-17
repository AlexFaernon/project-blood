using System.Collections.Generic;
using System.Linq;

public static class Recipes
{
    public static readonly Dictionary<HashSet<Food.Ingredient>, Food.Cocktail> Cocktails =
        new Dictionary<HashSet<Food.Ingredient>, Food.Cocktail>();

    public static List<Food.Cocktail> GetCocktailsByBlood(BloodSample bloodSample)
    {
        return Cocktails.Values.Where(cocktail => cocktail.BloodSample.Equals(bloodSample)).ToList();
    }
}
