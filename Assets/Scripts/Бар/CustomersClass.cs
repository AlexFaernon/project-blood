using System;
using System.Collections.Generic;
using System.Linq;

public static class CustomersClass
{
    private static List<Customer> Customers = new List<Customer>();
    public static Customer GetCurrentCustomer => Customers.Count > 0 ? Customers[0] : null;

    public static void RemoveCustomer(Customer customer)
    {
        Customers.Remove(customer);
    }
    public static void CreateNewCustomers()
    {
        var random = new Random();
        var randomSamples = BloodClass.BloodSamples.OrderBy(x => random.Next());
        
        random = new Random();
        foreach (var bloodSample in randomSamples)
        {
            var cocktails = Recipes.GetCocktailsByBlood(bloodSample);
            Customers.Add(new Customer(cocktails[random.Next(cocktails.Count)]));
        }
    }
}

public class Customer
{
    public readonly Food.Cocktail Cocktail;
    public string Order => Cocktail.Name;

    public Customer(Food.Cocktail cocktail)
    {
        Cocktail = cocktail;
    }
    
    public OrderStars CheckCocktail(Food.Cocktail cocktail)
    {
        CustomersClass.RemoveCustomer(this);
        
        if (Cocktail.Equals(cocktail))
        {
            return OrderStars.ThreeStars;
        }

        if (Cocktail.BloodSample.Equals(cocktail.BloodSample) && !Cocktail.PureBlood)
        {
            return OrderStars.TwoStars;
        }

        if (Cocktail.BloodSample.Equals(cocktail.BloodSample) && Cocktail.PureBlood)
        {
            return OrderStars.OneStar;
        }

        return OrderStars.NoStars;
    }
}

public enum OrderStars
{
    NoStars,
    OneStar,
    TwoStars,
    ThreeStars
}