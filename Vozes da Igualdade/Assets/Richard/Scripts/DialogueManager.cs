using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Diálogo deste NPC")]
    [TextArea(3, 6)]
    public string[] falas; // As falas específicas deste NPC

    [Header("Configuração de Interação")]
    public KeyCode teclaInteracao = KeyCode.E;

    private bool playerInRange = false;
    private bool dialogueStarted = false;

    public TextManager textManager; // Arraste no Inspector

    private void Update()
    {
        if (playerInRange && !dialogueStarted && Input.GetKeyDown(teclaInteracao))
        {
            IniciarDialogo();
        }
    }

    private void IniciarDialogo()
    {
        dialogueStarted = true;
        textManager.StartDialogue(falas);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueStarted = false; // Permite reiniciar diálogo ao sair e voltar
        }
    }
}