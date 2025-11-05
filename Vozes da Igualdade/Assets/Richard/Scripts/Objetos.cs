using UnityEngine;

public class Objetos : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;
    private bool playerInRangeI = false;
    [SerializeField] private GameObject poster;

    private TesteAndando playerMovement; // refer�ncia ao script de movimento

    public GameObject pressEE; // UI "Pressione E"

    void Start()
    {
        // Garantir que o "Pressione E" comece desativado
        if (pressEE != null)
            pressEE.SetActive(false);
    }

    void Update()
    {
        // Mostra/esconde o "Pressione E" dependendo se o jogador est� perto
        if (pressEE != null)
            pressEE.SetActive(playerInRange && !poster.activeSelf);

        // Intera��o ao apertar E
        if (playerInRange && Input.GetKeyDown(teclaInteracao))
            if (playerInRangeI && Input.GetKeyDown(teclaInteracao))
            {
                // Alterna o estado do poster
                bool novoEstado = !poster.activeSelf;
            }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInRangeI = true;
            playerMovement = other.GetComponent<TesteAndando>();

            // Mostra o "Pressione E"
            if (pressEE != null)
                pressEE.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInRangeI = false;
            poster.SetActive(false);

            // Garante que o player pode voltar a se mover ao sair da �rea
            if (playerMovement != null)
                playerMovement.canMove = true;

            // Esconde o "Pressione E"
            if (pressEE != null)
                pressEE.SetActive(false);
        }
    }
}