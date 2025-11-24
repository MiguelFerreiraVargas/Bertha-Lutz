using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int requiredItemId = 0; // ID do item necessário para abrir a porta (ex: chave)
    public string sceneToLoad = "Banheiro";      // Nome da cena de destino

    private bool isPlayerNear = false;
    private Inventoryy playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            playerInventory = other.GetComponent<Inventoryy>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            playerInventory = null;
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (playerInventory != null && HasRequiredItem())
            {
                // Abre a porta e troca de cena
                Debug.Log("Porta aberta!");
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Você precisa de um item para abrir esta porta!");
            }
        }
    }

    bool HasRequiredItem()
    {
        return playerInventory.items.Exists(item => item.id == requiredItemId && item.quantity > 0);
    }
}
