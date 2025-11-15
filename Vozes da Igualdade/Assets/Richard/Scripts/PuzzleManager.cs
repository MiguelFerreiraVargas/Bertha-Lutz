using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public GameObject piecePrefab;
    public Transform puzzleArea;
    public Sprite[] images;
    public GameObject itemReward;

    private List<PuzzlePieceDrag> pieces = new List<PuzzlePieceDrag>();
    private bool puzzleFinished = false;

    void Start()
    {
        if (images.Length != 16)
        {
            Debug.LogError($"Precisa de 16 imagens, mas tem {images.Length}!");
            return;
        }

        CreatePuzzle();
        ShufflePieces();

        Debug.Log("🧩 Puzzle iniciado com 16 peças");
    }

    void CreatePuzzle()
    {
        // Limpa peças existentes
        foreach (Transform child in puzzleArea)
        {
            Destroy(child.gameObject);
        }
        pieces.Clear();

        for (int i = 0; i < 16; i++)
        {
            GameObject piece = Instantiate(piecePrefab, puzzleArea);

            Image pieceImage = piece.GetComponent<Image>();
            if (pieceImage != null && i < images.Length)
                pieceImage.sprite = images[i];
            else
                Debug.LogError($"Imagem não encontrada para índice {i}");

            PuzzlePieceDrag drag = piece.GetComponent<PuzzlePieceDrag>();
            if (drag == null)
                drag = piece.AddComponent<PuzzlePieceDrag>();

            drag.correctIndex = i;
            drag.puzzleManager = this;

            pieces.Add(drag);
        }
    }

    void ShufflePieces()
    {
        // Método mais confiável de shuffle
        for (int i = 0; i < pieces.Count; i++)
        {
            int randomIndex = Random.Range(0, pieces.Count);
            pieces[i].transform.SetSiblingIndex(randomIndex);
        }

        Debug.Log("🔀 Peças embaralhadas");
    }

    public void CheckPuzzleSolved()
    {
        if (puzzleFinished) return;

        if (CheckSolved())
        {
            FinishPuzzle();
        }
    }

    bool CheckSolved()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            // Verifica se cada peça está na posição correta
            if (pieces[i].transform.GetSiblingIndex() != pieces[i].correctIndex)
            {
                return false;
            }
        }

        Debug.Log("✅ Todas as peças estão na posição correta!");
        return true;
    }

    void FinishPuzzle()
    {
        puzzleFinished = true;
        Debug.Log("🎉 Puzzle concluído!");

        // Ativa recompensa
        if (itemReward != null)
            itemReward.SetActive(true);

        // Desativa área do puzzle
        if (puzzleArea != null)
            puzzleArea.gameObject.SetActive(false);

        // Aqui você pode adicionar:
        // - Liberar movimento do player
        // - Mostrar mensagem de sucesso
        // - Transição para próxima fase
    }
}