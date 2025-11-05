using UnityEngine;

public class Objetos : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRangeI = false;
    [SerializeField] private GameObject poster;

    private TesteAndando playerMovement; // referência ao script de movimento

    void Update()
    {
        if (playerInRangeI && Input.GetKeyDown(teclaInteracao))
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
            playerInRangeI = true;
            playerMovement = other.GetComponent<TesteAndando>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRangeI = false;
            poster.SetActive(false);

            // Garante que o player pode voltar a se mover ao sair da área
            if (playerMovement != null)
                playerMovement.canMove = true;
        }
    }
}
