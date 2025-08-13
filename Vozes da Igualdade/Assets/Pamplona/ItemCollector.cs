using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o objeto tiver a tag "Item"
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject); // Remove o item
        }
    }
}
