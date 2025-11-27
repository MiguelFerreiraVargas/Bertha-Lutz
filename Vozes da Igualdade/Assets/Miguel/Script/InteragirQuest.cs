using UnityEngine;

public class InteragirQuest : MonoBehaviour
{
    public KeyCode tecla = KeyCode.E;
    private NPCMissao npcAtual = null;

    void Update()
    {
        if (npcAtual != null && Input.GetKeyDown(tecla))
        {
            npcAtual.Interagir();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<NPCMissao>())
            npcAtual = other.GetComponent<NPCMissao>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<NPCMissao>())
            npcAtual = null;
    }
}
