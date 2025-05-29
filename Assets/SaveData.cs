
using UnityEngine;
using System.Collections.Generic;
public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }
    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/Inventory.json";
        Debug.Log("Saving inventory to: " + filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Inventory saved successfully.");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/Inventory.json";
        if (System.IO.File.Exists(filePath))
        {
            string inventoryData = System.IO.File.ReadAllText(filePath);
            inventory = JsonUtility.FromJson<Inventory>(inventoryData);
            Debug.Log("Inventory loaded successfully from: " + filePath);
        }
        else
        {
            Debug.LogWarning("No save file found at: " + filePath);
        }
    }
}

[System.Serializable]
public class Inventory
{
    public int goldCoins;
    public bool isFull;
    public List<Item> items = new List<Item>();
}

[System.Serializable]
public class Item
{
    public string name;
    public string description;
}