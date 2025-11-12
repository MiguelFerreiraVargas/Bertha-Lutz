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
    public float typingSpeed = 0.04f;

    private string[] lines;
    private int currentLine;
    private Coroutine typingCoroutine;
    private bool isTyping;
    private bool dialogueActive;

    // Permite que outros scripts vejam se há um diálogo ativo
    public bool DialogueActive => dialogueActive;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(string[] newLines)
    {
        if (dialogueActive)
        {
            ForceEndDialogue(); // encerra diálogo anterior, se houver
        }

        lines = newLines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        dialogueActive = true;
        ShowLine();
    }

    void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(lines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void SkipTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = lines[currentLine];
        isTyping = false;
    }

    public bool NextLine()
    {
        // Se ainda está digitando, mostra tudo de uma vez
        if (isTyping)
        {
            SkipTyping();
            return false;
        }

        // Avança para próxima linha
        currentLine++;
        if (currentLine < lines.Length)
        {
            ShowLine();
            return false;
        }
        else
        {
            EndDialogue();
            return true; // diálogo acabou
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueActive = false;
    }

    public void ForceEndDialogue()
    {
        if (!dialogueActive) return;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        dialogueText.text = "";
        dialogueBox.SetActive(false);
        dialogueActive = false;
        isTyping = false;
    }
}
