using UnityEngine;

public class Objetos : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;

    [SerializeField] private GameObject poster;
    private TesteAndando playerMovement;

    public GameObject pressEE; // UI "Pressione E"

    void Start()
    {
        // Garante que o "Pressione E" comece desativado
        if (pressEE != null)
            pressEE.SetActive(false);
    }

    void Update()
    {
        // Mostra/esconde o "Pressione E" dependendo se o jogador está perto e o poster não está ativo
        if (pressEE != null)
            pressEE.SetActive(playerInRange && !poster.activeSelf);

        // Interação: apertar E quando o jogador está perto
        if (playerInRange && Input.GetKeyDown(teclaInteracao))
        {
            bool novoEstado = !poster.activeSelf;
            poster.SetActive(novoEstado);

            // Impede movimento do player quando o poster estiver ativo
            if (playerMovement != null)
                playerMovement.canMove = !novoEstado;

            // Esconde o "Pressione E" se o poster foi ativado
            if (pressEE != null && novoEstado)
                pressEE.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerMovement = other.GetComponent<TesteAndando>();

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

            if (playerMovement != null)
                playerMovement.canMove = true;

            if (pressEE != null)
                pressEE.SetActive(false);
        }
    }
}
