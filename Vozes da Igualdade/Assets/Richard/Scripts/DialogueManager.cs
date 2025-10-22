using UnityEngine;

public class DialogueSpawner : MonoBehaviour
{
    public GameObject dialoguePrefab;

    void Start()
    {
        if (dialoguePrefab != null)
        {
            Instantiate(dialoguePrefab);
        }
        else
        {
            Debug.LogError("Dialogue Prefab n�o atribu�do!");
        }
    }
}