using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveDataScript
{
    private static readonly BinaryFormatter binaryFormatter = new BinaryFormatter();
    
    public static void SaveBlood()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.BloodSavePath);
        binaryFormatter.Serialize(file, BloodClass.BloodSamples);
        file.Close();
    }

    public static void SaveShop()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.ShopSavePath);
        binaryFormatter.Serialize(file, Shop.ToggleIngredients);
        file.Close();
    }

    public static void SaveCustomers()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.CustomersSavePath);
        binaryFormatter.Serialize(file, CustomersClass.Customers);
        file.Close();
    }

    public static void SaveMoney()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.MoneySavePath);
        binaryFormatter.Serialize(file, Resources.Money);
        file.Close();
    }
    
    public static void SaveShaker()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.ShakerSavePath);
        binaryFormatter.Serialize(file, TableManager.Shaker);
        file.Close();
    }
    
    public static void SaveIngredientsOnTable()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.IngredientsOnTableSavePath);
        binaryFormatter.Serialize(file, TableManager.ingredientsOnTable);
        file.Close();
    }

    public static void SaveCurrentCocktail()
    {
        if (TableManager.CurrentCocktail == null)
        {
            File.Delete(Application.persistentDataPath + LoadDataScript.CurrentCocktailSavePath);
            return;
        }
        
        var file = File.Create(Application.persistentDataPath + LoadDataScript.CurrentCocktailSavePath);
        binaryFormatter.Serialize(file, TableManager.CurrentCocktail);
        file.Close();
    }

    public static void SaveCurrentBoardFruit()
    {
        if (TableManager.CurrentBoardFruit == null)
        {
            File.Delete(Application.persistentDataPath + LoadDataScript.CurrentBoardFruitSavePath);
            return;
        }
        
        var file = File.Create(Application.persistentDataPath + LoadDataScript.CurrentBoardFruitSavePath);
        binaryFormatter.Serialize(file, TableManager.CurrentBoardFruit);
        file.Close();
    }

    public static void SaveIsPiecesActive()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.IsPiecesActiveSavePath);
        binaryFormatter.Serialize(file, TableManager.IsPiecesActive);
        file.Close();
    }

    public static void SaveIsPeelActive()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.IsPeelActiveSavePath);
        binaryFormatter.Serialize(file, TableManager.IsPeelActive);
        file.Close();
    }

    public static void SaveCurrentJuicerFruit()
    {
        if (TableManager.CurrentJuicerFruit == null)
        {
            File.Delete(Application.persistentDataPath + LoadDataScript.CurrentJuicerFruitSavePath);
            return;
        }
        
        var file = File.Create(Application.persistentDataPath + LoadDataScript.CurrentJuicerFruitSavePath);
        binaryFormatter.Serialize(file, TableManager.CurrentJuicerFruit);
        file.Close();
    }

    public static void SaveIsGlassActive()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.IsGlassActiveSavePath);
        binaryFormatter.Serialize(file, TableManager.IsGlassActive);
        file.Close();
    }
    
    public static void SaveAllAttempts()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.AllAttemptsSavePath);
        binaryFormatter.Serialize(file, GlobalStatistics.allAttempts);
        file.Close();
    }
    
    public static void SaveSuccessfulAttempts()
    {
        var file = File.Create(Application.persistentDataPath + LoadDataScript.SuccessfulAttemptsSavePath);
        binaryFormatter.Serialize(file, GlobalStatistics.successfulAttempts);
        file.Close();
    }
}
