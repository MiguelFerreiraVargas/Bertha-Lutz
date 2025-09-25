using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;

public class ContextualizacaoDaHistoria : MonoBehaviour
{
 
    Item item;
    Inventoryy inventoryy;
    private bool itemId = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            inventoryy = other.GetComponent<Inventoryy>();
            if (inventoryy != null )
            {
                ItemsCountT();
            }
        }
    }
   void ItemsCountT ()
    {
        int tamanho = inventoryy.items.Count;
        if (tamanho == 1 && inventoryy.items[0].id == 0)
        {
            Debug.Log("item collected");
        }
    }
}
