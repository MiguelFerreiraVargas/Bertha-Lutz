using UnityEngine;

public class NPCSdialogue : MonoBehaviour
{
    [Header("Referências")]
    public GameObject puzzleImage;
    public DialogueManager dialogueManager;

    private bool puzzleAtivado = false;
    private bool dialogoIniciado = false;

    private TesteAndando testeAndando;

    void Start()
    {
        if (puzzleImage != null)
            puzzleImage.SetActive(false);

        // Pega o player no início (melhor prática)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            testeAndando = player.GetComponent<TesteAndando>();
        }
    }

    void Update()
    {
        if (dialogueManager == null || puzzleAtivado)
            return;

        // Detecta se o diálogo começou
        if (!dialogoIniciado && TextManager.Instance.DialogueActive)
        {
            dialogoIniciado = true;
        }

        // Se já começou e agora terminou → ativa o puzzle
        if (dialogoIniciado && !TextManager.Instance.DialogueActive)
        {
            AtivarPuzzle();
        }
    }

    void AtivarPuzzle()
    {
        puzzleAtivado = true;

        // trava o movimento
        if (testeAndando != null)
        {
            testeAndando.canMove = false;
            Debug.Log("Movimento bloqueado!");
        }
        else
        {
            Debug.LogWarning("⚠ TesteAndando não encontrado no Player!");
        }

        if (puzzleImage != null)
            puzzleImage.SetActive(true);

        Debug.Log("🧩 Puzzle ativado após o diálogo!");
    }
}
