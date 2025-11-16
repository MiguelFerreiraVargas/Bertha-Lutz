using UnityEngine;
using System.Collections;

public class NPCSdialogue : MonoBehaviour
{
    [Header("Referências")]
    public GameObject puzzleImage;
    public PuzzleManager puzzleManager;

    [Header("Diálogo pós-puzzle")]
    public string[] postPuzzleDialogue;

    [Header("Configurações de Input")]
    public KeyCode advanceKey = KeyCode.E;

    private bool puzzleAtivado = false;
    private bool dialogoIniciado = false;
    private bool aguardandoDialogoPosPuzzle = false;
    private TesteAndando testeAndando;

    void Start()
    {
        if (puzzleImage != null)
            puzzleImage.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            testeAndando = player.GetComponent<TesteAndando>();

        if (puzzleManager != null)
            puzzleManager.OnPuzzleCompleted += OnPuzzleCompleted;
    }

    void Update()
    {
        // Controle do diálogo inicial do NPC
        if (!puzzleAtivado)
        {
            if (!dialogoIniciado && TextManager.Instance.DialogueActive)
            {
                dialogoIniciado = true;
            }

            if (dialogoIniciado && !TextManager.Instance.DialogueActive)
            {
                AtivarPuzzle();
            }
        }

        // Controle do diálogo pós-puzzle
        if (aguardandoDialogoPosPuzzle && Input.GetKeyDown(advanceKey))
        {
            AvancarDialogoPosPuzzle();
        }
    }

    void AtivarPuzzle()
    {
        puzzleAtivado = true;

        if (testeAndando != null)
            testeAndando.canMove = false;

        if (puzzleImage != null)
            puzzleImage.SetActive(true);

        Debug.Log("🧩 Puzzle ativado após o diálogo!");
    }

    void OnPuzzleCompleted()
    {
        Debug.Log("💬 Puzzle completado! Preparando diálogo pós-puzzle...");

        if (testeAndando != null)
            testeAndando.canMove = true;

        // Inicia o diálogo pós-puzzle
        if (postPuzzleDialogue.Length > 0)
        {
            StartCoroutine(IniciarDialogoPosPuzzle());
        }
        else
        {
            Debug.LogWarning("❌ Nenhum diálogo pós-puzzle configurado");
            FinalizarTudo();
        }
    }

    IEnumerator IniciarDialogoPosPuzzle()
    {
        // Pequeno delay para garantir que tudo está pronto
        yield return new WaitForSeconds(0.1f);

        TextManager.Instance.StartDialogue(postPuzzleDialogue);
        aguardandoDialogoPosPuzzle = true;

        Debug.Log("💬 Diálogo pós-puzzle iniciado. Pressione " + advanceKey + " para avançar.");
    }

    void AvancarDialogoPosPuzzle()
    {
        // Chama NextLine do TextManager
        bool dialogoAcabou = TextManager.Instance.NextLine();

        if (dialogoAcabou)
        {
            aguardandoDialogoPosPuzzle = false;
            FinalizarTudo();
        }
    }

    void FinalizarTudo()
    {
        if (puzzleImage != null)
            puzzleImage.SetActive(false);

        Debug.Log("🎯 Tudo finalizado! Puzzle e diálogo concluídos.");
    }

    void OnDestroy()
    {
        if (puzzleManager != null)
            puzzleManager.OnPuzzleCompleted -= OnPuzzleCompleted;
    }
}