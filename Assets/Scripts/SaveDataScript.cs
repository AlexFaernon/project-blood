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
}
