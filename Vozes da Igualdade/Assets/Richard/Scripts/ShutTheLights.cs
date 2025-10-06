using UnityEngine;

public class ShutTheLights : MonoBehaviour
{
    [SerializeField] Sprite spriteNormal;
    [SerializeField] Sprite spriteMask;

    private SpriteRenderer spriteRenderer;
    private Inventoryy inventory;
    private bool isHidden = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = spriteNormal;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (inventory != null && inventory.items.Exists(item => item.id == 1))
            {
                ToggleHidden();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory = other.GetComponent<Inventoryy>();
        }
    }

    private void ToggleHidden()
    {
        isHidden = !isHidden;

        if (isHidden && spriteMask != null)
            spriteRenderer.sprite = spriteMask;
        else if (!isHidden && spriteNormal != null)
            spriteRenderer.sprite = spriteNormal;

        Debug.Log("Hidden toggled: " + isHidden);
    }
}