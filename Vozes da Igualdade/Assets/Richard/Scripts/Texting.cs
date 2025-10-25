
using UnityEngine;

public class Texting : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    private bool playerInRange = false;
    private bool dialogueStarted = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (TextManager.Instance != null)
            {
                // Se o diálogo ainda não começou, inicia ele
                if (!dialogueStarted)
                {
                    TextManager.Instance.StartDialogue(lines);
                    dialogueStarted = true;
                }
                // Se já começou, o próprio TextManager vai tratar o avanço das falas
            }
        }

        // Quando o diálogo termina (caixa desativada), resetamos
        if (dialogueStarted && !TextManager.Instance.dialogueBox.activeSelf)
        {
            dialogueStarted = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}