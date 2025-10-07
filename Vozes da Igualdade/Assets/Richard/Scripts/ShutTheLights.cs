using UnityEngine;

public class ShutTheLights : MonoBehaviour
{
    [SerializeField] private Sprite spriteNormal;
    [SerializeField] private Sprite spriteMask;
    private SpriteRenderer spriteRenderer;

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
            SpriteChange();
        }
    }

    public void SpriteChange()
    {
        isHidden = !isHidden;

        if (isHidden && spriteMask != null)
            spriteRenderer.sprite = spriteMask;
        else if (!isHidden && spriteNormal != null)
            spriteRenderer.sprite = spriteNormal;

        Debug.Log("Hidden toggled: " + isHidden);
    }
}
