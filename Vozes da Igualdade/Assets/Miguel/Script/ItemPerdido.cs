using UnityEngine;

public class ItemPerdido : MonoBehaviour
{
    public NPCMissao npc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            npc.JogadorPegouItem();
            Debug.Log("Item coletado!");
            Destroy(gameObject);
        }
    }
}
