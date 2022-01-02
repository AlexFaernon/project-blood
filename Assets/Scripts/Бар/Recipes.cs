using System.Collections.Generic;
using System.Linq;

public static class Recipes
{
    public static readonly List<Food.Cocktail> Cocktails =
        new List<Food.Cocktail>();

    public static List<Food.Cocktail> GetCocktailsByBlood(BloodSample bloodSample)
    {
        return Cocktails.Where(cocktail => cocktail.BloodSample.Equals(bloodSample)).ToList();
    }
}
