using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventoryy : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
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

    public int maxSlots = 10;            
    public List<Item> items = new List<Item>();  
       public void AddItem(string name, int id, string description, Sprite icon, int value)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventario cheio!");
            return;
        }

        Item newItem = new Item(name, id, description, icon, value);
        items.Add(newItem);
        Debug.Log($"Item adicionado: {name} (ID: {id})");
    }

}