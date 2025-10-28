using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Di�logo deste NPC")]
    [TextArea(3, 6)]
    public string[] falas; // As falas espec�ficas deste NPC

    [Header("Configura��o de Intera��o")]
    public KeyCode teclaInteracao = KeyCode.E;

    private bool playerInRange = false;
    private bool dialogueStarted = false;

    private void Update()
    {
        // Verifica se o jogador est� na �rea e apertou a tecla para iniciar o di�logo
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
            // Aqui voc� pode ativar um �cone de "Pressione E"
        }
    }
}