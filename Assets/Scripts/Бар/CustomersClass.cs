using System;
using System.Collections.Generic;
using System.Linq;

public static class CustomersClass
{
    //todo saved
    public static List<Customer> Customers { get; private set; } = new List<Customer>();
    public static Customer CurrentCustomer => Customers.Count > 0 ? Customers[0] : null;

    public static void RemoveCustomer(Customer customer)
    {
        Customers.Remove(customer);
        SaveDataScript.SaveCustomers();
    }

    public static void LoadCustomers(List<Customer> customers)
    {
        Customers = customers;
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
        
        SaveDataScript.SaveCustomers();
    }
}

[Serializable]
public class Customer
{
    public readonly Food.Cocktail Cocktail;
    public string Order => Cocktail.Name;
    public string Blood => Cocktail.BloodSample.ToString();

    public Customer(Food.Cocktail cocktail)
    {
        Cocktail = cocktail;
    }
    
    public OrderStars CheckCocktail(Food.Cocktail cocktail)
    {
        CustomersClass.RemoveCustomer(this);
        
        if (Cocktail.Equals(cocktail))
        {
            DailyStatistics.AddRecord(OrderStars.ThreeStars, Cocktail.BloodSample, cocktail.BloodSample);
            GlobalStatistics.AddAttempt(cocktail.BloodSample, true);
            return OrderStars.ThreeStars;
        }

        if (Cocktail.BloodSample.Equals(cocktail.BloodSample) && !cocktail.PureBlood)
        {
            DailyStatistics.AddRecord(OrderStars.TwoStars, Cocktail.BloodSample, cocktail.BloodSample);
            GlobalStatistics.AddAttempt(cocktail.BloodSample, true);
            return OrderStars.TwoStars;
        }

        if (Cocktail.BloodSample.Equals(cocktail.BloodSample) && cocktail.PureBlood)
        {
            DailyStatistics.AddRecord(OrderStars.OneStar, Cocktail.BloodSample, cocktail.BloodSample);
            GlobalStatistics.AddAttempt(cocktail.BloodSample, true);
            return OrderStars.OneStar;
        }

        DailyStatistics.AddRecord(OrderStars.NoStars, Cocktail.BloodSample, cocktail.BloodSample);
        GlobalStatistics.AddAttempt(cocktail.BloodSample, false);
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