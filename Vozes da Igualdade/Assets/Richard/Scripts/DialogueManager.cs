using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [TextArea(3, 6)]
    public string[] falas;

    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;
    private bool dialogueAtivo = false;

    public GameObject pressE;

    private TesteAndando playerMove;

    void Start()
    {
        // Garantir que o "Pressione E" comece desativado
        if (pressE != null)
            pressE.SetActive(false);
    }

    void Update()
    {
        // Interação com NPC
        if (playerInRange && Input.GetKeyDown(teclaInteracao))
        {
            if (!dialogueAtivo)
                StartDialogue();
            else
                EndDialogue();
        }
    }

    private void StartDialogue()
    {
        Debug.Log($"{name}: Iniciando diálogo");
        TextManager.Instance.StartDialogue(falas);
        dialogueAtivo = true;

        // Impede o movimento do jogador
        if (playerMove != null)
            playerMove.canMove = false;

        UpdatePressE();
    }

    private void EndDialogue()
    {
        Debug.Log($"{name}: Finalizando diálogo");
        TextManager.Instance.ForceEndDialogue();
        dialogueAtivo = false;

        // Libera o movimento do jogador
        if (playerMove != null)
            playerMove.canMove = true;

        UpdatePressE();
    }

    private void UpdatePressE()
    {
        if (pressE != null)
            pressE.SetActive(playerInRange && !dialogueAtivo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerMove = other.GetComponent<TesteAndando>();
            UpdatePressE(); // Atualiza o "Pressione E" quando o player entra
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Força o fim do diálogo se o player sair do range
            EndDialogue();

            // Esconde o "Pressione E"
            UpdatePressE();

            // Remove referência do player
            playerMove = null;
        }
    }
}
