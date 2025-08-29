using UnityEngine;

public class CondicaoDeSaida : MonoBehaviour
{
    public Inventoryy inventory;  // inventário do Player
    public int itemIdParaVencer;  // ID do item que abre a porta
    [SerializeField] GameObject porta;  // porta a ser destruída

    private void Start()
    {
        porta.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pega o inventário do Player
            Inventoryy playerInventory = other.GetComponent<Inventoryy>();
            if (playerInventory != null)
            {
                // Procura o item necessário
                Item item = playerInventory.items.Find(i => i.id == itemIdParaVencer);
                bool temItem = (item != null && item.quantity > 0);

                if (temItem)
                {
                    // Destrói a porta
                    porta.SetActive(false);
                    Debug.Log("Porta aberta!");
                }
                else
                {
                    Debug.Log("Você precisa do item para abrir a porta.");
                }
            }
        }
    }
}
