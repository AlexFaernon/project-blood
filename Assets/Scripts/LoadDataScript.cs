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
    private static readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void LoadAll()
    {
        LoadBlood();
        LoadShop();
        LoadCustomers();
        LoadMoney();
        LoadShaker();
        LoadIngredientsOnTable();
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
}
