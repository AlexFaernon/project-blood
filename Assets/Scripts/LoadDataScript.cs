using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LoadDataScript
{
    public const string BloodSavePath = "/BloodSaves.bp";
    public const string ShopSavePath = "/ShopSave.bp";
    public const string CustomersSavePath = "/CustomersSave.bp";
    public const string MoneySavePath = "/MoneySave.bp";
    public const string ShakerSavePath = "/ShakerSave.bp";
    public const string IngredientsOnTableSavePath = "/IgredientsOnTableSave.bp";
    public const string CurrentCocktailSavePath = "/CurrentCocktailSave.bp";
    public const string CurrentBoardFruitSavePath = "/CurrentBoardFruitSave.bp";
    public const string IsPiecesActiveSavePath = "/IsPiecesActiveSave.bp";
    public const string IsPeelActiveSavePath = "/IsPeelActiveSave.bp";
    public const string CurrentJuicerFruitSavePath = "/CurrentJuicerFruitSave.bp";
    public const string IsGlassActiveSavePath = "/IsGlassActiveSave.bp";
    public const string AllAttemptsSavePath = "/AttemptsSavePath.bp";
    public const string SuccessfulAttemptsSavePath = "/SuccessfulSavePath.bp";
    public const string IngredientsSavePath = "/Ingredients.bp";
    public const string DailyStatisticsSavePath = "/DailyStatistics.bp";

    public static readonly object[] IngredientsKeys =
    {
        Food.Fruits.Apple,
        Food.Fruits.Lemon,
        Food.Fruits.Lime,
        Food.Fruits.Pineapple,
        Food.Fruits.Orange,
        Food.Fruits.Celery,
        Food.Miscellaneous.Carnation,
        Food.Miscellaneous.Coffee,
        Food.Miscellaneous.Honey,
        Food.Miscellaneous.Pepper
    };
    
    private static readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void LoadAll()
    {
        LoadBlood();
        LoadShop();
        LoadCustomers();
        LoadMoney();
        LoadShaker();
        LoadIngredientsOnTable();
        LoadCurrentCocktail();
        LoadCurrentBoardFruit();
        LoadIsPiecesActive();
        LoadIsPeelActive();
        LoadCurrentJuicerFruit();
        LoadIsGlassActive();
        LoadAllAttempts();
        LoadSuccessfulAttempts();
        LoadIngredients();
        LoadDailyStatistics();
    }
    
    private static void LoadBlood()
    {
        if (File.Exists(Application.persistentDataPath + BloodSavePath))
        {
            var file = File.Open(Application.persistentDataPath + BloodSavePath, FileMode.Open);
            BloodClass.LoadBloodSamples((List<BloodSample>)binaryFormatter.Deserialize(file));
            file.Close();
        }
    }
    
    private static void LoadShop()
    {
        if (File.Exists(Application.persistentDataPath + ShopSavePath))
        {
            var file = File.Open(Application.persistentDataPath + ShopSavePath, FileMode.Open);
            Shop.ToggleIngredients = (bool)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadCustomers()
    {
        if (File.Exists(Application.persistentDataPath + CustomersSavePath))
        {
            var file = File.Open(Application.persistentDataPath + CustomersSavePath, FileMode.Open);
            CustomersClass.LoadCustomers((List<Customer>)binaryFormatter.Deserialize(file));
            file.Close();
        }
    }
    
    private static void LoadMoney()
    {
        if (File.Exists(Application.persistentDataPath + MoneySavePath))
        {
            var file = File.Open(Application.persistentDataPath + MoneySavePath, FileMode.Open);
            Resources.Money = (int)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }
    
    private static void LoadShaker()
    {
        if (File.Exists(Application.persistentDataPath + ShakerSavePath))
        {
            var file = File.Open(Application.persistentDataPath + ShakerSavePath, FileMode.Open);
            TableManager.Shaker = (HashSet<Food.Ingredient>)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }
    
    private static void LoadIngredientsOnTable()
    {
        if (File.Exists(Application.persistentDataPath + IngredientsOnTableSavePath))
        {
            var file = File.Open(Application.persistentDataPath + IngredientsOnTableSavePath, FileMode.Open);
            TableManager.LoadIngredients((List<Food.Ingredient>)binaryFormatter.Deserialize(file));
            file.Close();
        }
    }

    private static void LoadCurrentCocktail()
    {
        if (File.Exists(Application.persistentDataPath + CurrentCocktailSavePath))
        {
            var file = File.Open(Application.persistentDataPath + CurrentCocktailSavePath, FileMode.Open);
            TableManager.CurrentCocktail = (Food.Cocktail)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadCurrentBoardFruit()
    {
        if (File.Exists(Application.persistentDataPath + CurrentBoardFruitSavePath))
        {
            var file = File.Open(Application.persistentDataPath + CurrentBoardFruitSavePath, FileMode.Open);
            TableManager.CurrentBoardFruit = (Food.Fruits)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadIsPiecesActive()
    {
        if (File.Exists(Application.persistentDataPath + IsPiecesActiveSavePath))
        {
            var file = File.Open(Application.persistentDataPath + IsPiecesActiveSavePath, FileMode.Open);
            TableManager.IsPiecesActive = (bool)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadIsPeelActive()
    {
        if (File.Exists(Application.persistentDataPath + IsPeelActiveSavePath))
        {
            var file = File.Open(Application.persistentDataPath + IsPeelActiveSavePath, FileMode.Open);
            TableManager.IsPeelActive = (bool)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadCurrentJuicerFruit()
    {
        if (File.Exists(Application.persistentDataPath + CurrentJuicerFruitSavePath))
        {
            var file = File.Open(Application.persistentDataPath + CurrentJuicerFruitSavePath, FileMode.Open);
            TableManager.CurrentJuicerFruit = (Food.Fruits)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static void LoadIsGlassActive()
    {
        if (File.Exists(Application.persistentDataPath + IsGlassActiveSavePath))
        {
            var file = File.Open(Application.persistentDataPath + IsGlassActiveSavePath, FileMode.Open);
            TableManager.IsGlassActive = (bool)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }
    
    private static void LoadAllAttempts()
    {
        if (File.Exists(Application.persistentDataPath + AllAttemptsSavePath))
        {
            var file = File.Open(Application.persistentDataPath + AllAttemptsSavePath, FileMode.Open);
            GlobalStatistics.LoadAllAttempts((int[,])binaryFormatter.Deserialize(file));
            file.Close();
        }
    }
    
    private static void LoadSuccessfulAttempts()
    {
        if (File.Exists(Application.persistentDataPath + SuccessfulAttemptsSavePath))
        {
            var file = File.Open(Application.persistentDataPath + SuccessfulAttemptsSavePath, FileMode.Open);
            GlobalStatistics.LoadSuccessfulAttempts((int[,])binaryFormatter.Deserialize(file));
            file.Close();
        }
    }

    private static void LoadIngredients()
    {
        if (File.Exists(Application.persistentDataPath + IngredientsSavePath))
        {
            var file = File.Open(Application.persistentDataPath + IngredientsSavePath, FileMode.Open);
            var values = (int[])binaryFormatter.Deserialize(file);
            if (values.Length != IngredientsKeys.Length)
            {
                throw new ArgumentException("Arrays has different lengths");
            }

            for (var i = 0; i < IngredientsKeys.Length; i++)
            {
                Food.Ingredients[IngredientsKeys[i]] = values[i];
            }
            
            file.Close();
        }
    }

    private static void LoadDailyStatistics()
    {
        if (File.Exists(Application.persistentDataPath + DailyStatisticsSavePath))
        {
            var file = File.Open(Application.persistentDataPath + DailyStatisticsSavePath, FileMode.Open);
            DailyStatistics.Records = (List<StatisticRecord>)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }
}
