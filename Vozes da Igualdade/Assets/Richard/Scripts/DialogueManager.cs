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

    private void Update()
    {
        // Verifica se o jogador está na área e apertou a tecla para iniciar o diálogo
        if (playerInRange && !dialogueStarted && Input.GetKeyDown(teclaInteracao))
        {
            IniciarDialogo();
        }
    }

    private void IniciarDialogo()
    {
        if (TextManager.Instance != null)
        {
            dialogueStarted = true;
            TextManager.Instance.StartDialogue(falas);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Aqui você pode ativar um ícone de "Pressione E"
        }
    }
}