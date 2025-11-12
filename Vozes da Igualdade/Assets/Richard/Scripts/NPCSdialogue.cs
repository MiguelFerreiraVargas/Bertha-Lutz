using UnityEngine;

public class NPCSdialogue : MonoBehaviour
{
    [Header("Referências")]
    public GameObject puzzleImage; // painel ou imagem do puzzle
    public DialogueManager dialogueManager; // o NPC que dispara o diálogo

    private bool puzzleAtivado = false;

    void Start()
    {
        if (puzzleImage != null)
            puzzleImage.SetActive(false);
    }

    void Update()
    {
        // Só ativa o puzzle se o diálogo tiver terminado
        if (!puzzleAtivado && dialogueManager != null)
        {
            // Verifica se o diálogo acabou (ou seja, não está ativo)
            if (!TextManager.Instance.DialogueActive && dialogueManager.gameObject.activeInHierarchy)
            {
                // Ativa o puzzle uma única vez
                AtivarPuzzle();
            }
        }
    }

    void AtivarPuzzle()
    {
        puzzleAtivado = true;

        if (puzzleImage != null)
            puzzleImage.SetActive(true);

        Debug.Log("🧩 Puzzle ativado após o diálogo!");
    }
}