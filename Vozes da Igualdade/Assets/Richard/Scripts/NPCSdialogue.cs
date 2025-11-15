using UnityEngine;

public class NPCSdialogue : MonoBehaviour
{
    [Header("Referências")]
    public GameObject puzzleImage;          // Contém o PuzzleManager
    public DialogueManager dialogueManager;

    private bool puzzleAtivado = false;
    private bool dialogoIniciado = false;

    private TesteAndando testeAndando;

    void Start()
    {
        if (puzzleImage != null)
            puzzleImage.SetActive(false);

        // Pega o player no início
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            testeAndando = player.GetComponent<TesteAndando>();
    }

    void Update()
    {
        if (dialogueManager == null || puzzleAtivado)
            return;

        // Detecta início do diálogo
        if (!dialogoIniciado && TextManager.Instance.DialogueActive)
            dialogoIniciado = true;

        // Detecta fim do diálogo
        if (dialogoIniciado && !TextManager.Instance.DialogueActive)
            AtivarPuzzle();
    }

    void AtivarPuzzle()
    {
        puzzleAtivado = true;

        // Trava movimento do player
        if (testeAndando != null)
            testeAndando.canMove = false;

        // Ativa puzzle
        if (puzzleImage != null)
            puzzleImage.SetActive(true);

        Debug.Log("🧩 Puzzle ativado após o diálogo!");
    }
}
