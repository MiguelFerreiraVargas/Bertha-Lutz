using UnityEngine;

public class CondicaoDeSaida : MonoBehaviour
{
    public Inventoryy inventory;  // inventário do Playe
    public int itemIdParaVencer;  // ID do item que abre a porta

    [SerializeField] private GameObject porta;  // porta a ser desativ;
    private void Start()
    {
        if (porta != null)
            porta.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pega o inventário do Player
            Inventoryy playerInventory = other.GetComponent<Inventoryy>();
            if (playerInventory == null) return;

            // Procura o item necessário
            Item item = playerInventory.items.Find(i => i.id == itemIdParaVencer);

            if (item != null && item.quantity > 0)
            {
                // Abre a porta
                porta.SetActive(false);
                Debug.Log("Porta aberta!");
            }
        }
    }
}
