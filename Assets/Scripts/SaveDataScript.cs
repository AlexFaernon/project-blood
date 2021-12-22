using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveDataScript
{
    private static BinaryFormatter binaryFormatter = new BinaryFormatter();
    
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
        var file = File.Create(Application.persistentDataPath + LoadDataScript.CurrentCocktailSavePath);
        binaryFormatter.Serialize(file, TableManager.CurrentCocktail);
        file.Close();
    }

    public static void SaveCurrentBoardFruit()
    {
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
}
