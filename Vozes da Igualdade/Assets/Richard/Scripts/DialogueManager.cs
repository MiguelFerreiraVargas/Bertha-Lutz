using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [TextArea(3, 6)]
    public string[] falas;

    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRange = false;
    private bool dialogueAtivo = false;

    public GameObject pressE; // ícone "Pressione E"
    private TesteAndando playerMove; // referência ao script de movimento

    void Start()
    {
        if (pressE != null)
            pressE.SetActive(false);
    }

    void Update()
    {
        if (!playerInRange)
            return;

        if (Input.GetKeyDown(teclaInteracao))
        {
            if (!dialogueAtivo)
            {
                StartDialogue();
            }
            else
            {
                // avança o diálogo ou encerra se terminou
                if (TextManager.Instance != null)
                {
                    bool acabou = TextManager.Instance.NextLine();
                    if (acabou)
                        EndDialogue();
                }
            }
        }
    }

    private void StartDialogue()
    {
        if (TextManager.Instance == null)
            return;

        // Evita iniciar outro diálogo se já há um ativo
        if (TextManager.Instance.DialogueActive)
            return;

        Debug.Log($"{name}: Iniciando diálogo");
        dialogueAtivo = true;

        TextManager.Instance.StartDialogue(falas);

        // Impede o movimento do jogador
        if (playerMove != null)
            playerMove.canMove = false;

        UpdatePressE();
    }

    private void EndDialogue()
    {
        Debug.Log($"{name}: Finalizando diálogo");
        dialogueAtivo = false;

        if (TextManager.Instance != null)
            TextManager.Instance.ForceEndDialogue();

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
            UpdatePressE();
        }

        if (other.CompareTag("Falas"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            EndDialogue();
            UpdatePressE();
            playerMove = null;
        }
    }
}
