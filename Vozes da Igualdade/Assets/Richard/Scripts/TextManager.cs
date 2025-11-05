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


    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
                SkipTyping();
            else
                NextLine();
        }
    }

    public void  StartDialogue(string[] newLines)
    {
        if (dialogueActive)
        {
            ForceEndDialogue(); // encerra o diálogo anterior
        }

        lines = newLines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        dialogueActive = true;
        ShowLine();
    }

    void ShowLine()
    {
        //if (typingCoroutine != null)
        //    StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(lines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        Debug.Log("Digitando com typingSpeed = " + typingSpeed);

        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void SkipTyping()
    {
        //if (typingCoroutine != null)
        //    StopCoroutine(typingCoroutine);

        dialogueText.text = lines[currentLine];
        isTyping = false;
    }

    void NextLine()
    {
        if (currentLine < lines.Length - 1)
        {
            currentLine++;
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueActive = false;
    }

    public void ForceEndDialogue()
    {
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
