
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
                // Se o di�logo ainda n�o come�ou, inicia ele
                if (!dialogueStarted)
                {
                    TextManager.Instance.StartDialogue(lines);
                    dialogueStarted = true;
                }
                // Se j� come�ou, o pr�prio TextManager vai tratar o avan�o das falas
            }
        }

        // Quando o di�logo termina (caixa desativada), resetamos
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