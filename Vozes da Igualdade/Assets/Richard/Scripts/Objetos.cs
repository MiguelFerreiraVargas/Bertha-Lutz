using UnityEngine;

public class Objetos : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;
    [SerializeField] private GameObject poster;

    private TesteAndando playerMovement; // referência ao script de movimento

    public GameObject pressEE; // UI "Pressione E"

    void Start()
    {
        // Garantir que o "Pressione E" comece desativado
        if (pressEE != null)
            pressEE.SetActive(false);
    }

    void Update()
    {
        // Mostra/esconde o "Pressione E" dependendo se o jogador está perto
        if (pressEE != null)
            pressEE.SetActive(playerInRange && !poster.activeSelf);

        // Interação ao apertar E
        if (playerInRange && Input.GetKeyDown(teclaInteracao))
        {
            // Alterna o estado do poster
            bool novoEstado = !poster.activeSelf;
            poster.SetActive(novoEstado);

            // Liga/desliga o movimento do jogador
            if (playerMovement != null)
                playerMovement.canMove = !novoEstado;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerMovement = other.GetComponent<TesteAndando>();

            // Mostra o "Pressione E"
            if (pressEE != null)
                pressEE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            poster.SetActive(false);

            // Garante que o player pode voltar a se mover ao sair da área
            if (playerMovement != null)
                playerMovement.canMove = true;

            // Esconde o "Pressione E"
            if (pressEE != null)
                pressEE.SetActive(false);
        }
    }
}
