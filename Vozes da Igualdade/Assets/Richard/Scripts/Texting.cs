using UnityEngine;

public class Texting : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;

    private bool hasInteracted = false;

    public void Interact()
    {
        if (hasInteracted) return;

        hasInteracted = true;
        TextManager.Instance.StartDialogue(lines);

    }
}