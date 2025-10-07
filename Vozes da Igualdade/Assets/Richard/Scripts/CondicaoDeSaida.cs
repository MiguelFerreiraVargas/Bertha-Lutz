using UnityEngine;

public class CondicaoDeSaida : MonoBehaviour
{
    public Inventoryy inventory;  // inventário do Player
    [SerializeField] private ShutTheLights shutTheLights; // referenciado no inspetor
    public int itemIdParaVencer;  // ID do item que abre a porta

    [SerializeField] private GameObject porta;  // porta a ser desativada

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

                // Ativa a mudança de sprite
                if (shutTheLights != null)
                {
                    shutTheLights.SpriteChange(); // <- método novo (ver abaixo)
                }
                else
                {
                    Debug.LogWarning("ShutTheLights não foi atribuído!");
                }
            }
            else
            {
                Debug.Log("Você precisa do item para abrir a porta.");
            }
        }
    }
}
