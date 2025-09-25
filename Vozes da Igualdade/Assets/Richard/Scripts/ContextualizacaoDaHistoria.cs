using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;

public class ContextualizacaoDaHistoria : MonoBehaviour
{
  //[SerializeField] GameObject primeiraPagina;
  //[SerializeField] GameObject botaoAveriguar;
  //[SerializeField] GameObject objetoTeste;
    Item item;
    Inventoryy inventoryy;
    private bool itemId = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //botaoAveriguar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

            Debug.Log("LALALALALLAL");
        }
    }
}
