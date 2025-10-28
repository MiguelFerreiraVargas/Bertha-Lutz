using TMPro;
using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour
{
    public static TextManager Instance;

    [Header("UI Elements")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.04f; // Tempo entre cada letra

    private string[] lines;
    private int currentLine;
    public bool isTyping { get; private set; }

    private void Awake()
    {
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueBox.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                // Pula a digitação
                StopAllCoroutines();
                dialogueText.text = lines[currentLine];
                isTyping = false;
            }
            else
            {
                currentLine++;
                if (lines != null && currentLine < lines.Length)
                {
                    StartCoroutine(TypeLine(lines[currentLine]));
                }
                else
                {
                    dialogueBox.SetActive(false);
                }
            }
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogWarning("StartDialogue chamado com array vazio ou nulo!");
            return;
        }

        lines = dialogueLines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine(lines[currentLine]));
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        isTyping = true;

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}