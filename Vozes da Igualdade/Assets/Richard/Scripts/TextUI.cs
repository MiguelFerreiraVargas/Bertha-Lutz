using UnityEngine;

public class TextUI : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;
    private bool hasInteracted = false;

    // Reference to TextEnding component
    private TextEnding textEnding;
    public GameObject backMenu;

    void Update()
    {
        // Check if textEnding exists before accessing it
        if (textEnding != null && !textEnding.isTyping)
        {
            backMenu.SetActive(true);
        }
        else if (textEnding == null)
        {
            // Try to find TextEnding if it's still null
            textEnding = FindAnyObjectByType<TextEnding>();
        }
    }

    private void Start()
    {
        // Get reference to TextEnding component
        textEnding = FindAnyObjectByType<TextEnding>();

        // Start dialogue automatically
        Interactede();
        backMenu.SetActive(false);
    }

    void Interactede()
    {
        if (hasInteracted) return;

        hasInteracted = true;

        // Check if TextEnding exists before using it
        if (textEnding != null)
        {
            textEnding.StartDialogue(lines);
        }
        else
        {
            Debug.LogError("TextEnding component is missing! Make sure there's a TextEnding object in the scene.");
        }
    }
}