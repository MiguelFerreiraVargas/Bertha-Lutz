using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [TextArea(3, 6)]
    public string[] falas;
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(teclaInteracao))
        {
            TextManager.Instance.StartDialogue(falas);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            TextManager.Instance.ForceEndDialogue();
        }
    }
}