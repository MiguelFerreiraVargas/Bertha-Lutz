using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventoryy : MonoBehaviour
{
    public int maxSlots = 6;            
    public List<Item> items = new List<Item>();
    public void AddItem(string name, int id, string description, Sprite icon, int value)
    {
        
        Item existingItem = items.Find(item => item.id == id);

        if (existingItem != null)
        {
            existingItem.quantity++;
            Debug.Log($"Quantidade do item {name} aumentada para {existingItem.quantity}");
        }
        else
        {
            if (items.Count >= maxSlots)
            {
                Debug.Log("Invent�rio cheio!");
                return;
            }

            Item newItem = new Item(name, id, description, icon, value);
            items.Add(newItem);
            Debug.Log($"Item adicionado: {name} (ID: {id})");
        }
    }
}
[System.Serializable]
public class Item
{
    public int quantity = 1;
    public string name;
    public int id;
    public string description;
    public Sprite icon;
    public int value;

    public Item(string name, int id, string description, Sprite icon, int value)
    {
        this.name = name;
        this.id = id;
        this.description = description;
        this.icon = icon;
        this.value = value;
    }
}