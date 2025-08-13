using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string name;
        public int id;

        public Item(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }

    public int maxSlots = 10;            
    public List<Item> items = new List<Item>();  

   
    public void AddItem(string name, int id)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventário cheio!");
            return;
        }

        Item newItem = new Item(name, id);
        items.Add(newItem);
        Debug.Log($"Item adicionado: {name} (ID: {id})");
    }
 }