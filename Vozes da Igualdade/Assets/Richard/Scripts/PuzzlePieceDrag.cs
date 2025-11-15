using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePieceDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int correctIndex;
    public PuzzleManager puzzleManager;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Verifica se soltou em cima de outra peça
        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        if (target != null && target != gameObject && target.GetComponent<PuzzlePieceDrag>() != null)
        {
            // Troca as posições
            int targetIndex = target.transform.GetSiblingIndex();
            int currentIndex = transform.GetSiblingIndex();

            transform.SetSiblingIndex(targetIndex);
            target.transform.SetSiblingIndex(currentIndex);
        }
        else
        {
            // Volta para posição original
            rectTransform.anchoredPosition = originalPosition;
        }

        // Verifica se o puzzle foi resolvido
        if (puzzleManager != null)
            puzzleManager.CheckPuzzleSolved();
    }

    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas != null ? canvas.scaleFactor : 1f;
    }
}