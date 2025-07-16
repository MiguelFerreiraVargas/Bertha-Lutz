using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite idleSprite;
    public Sprite walkSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Entrada WASD
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Trocar sprite de acordo com dire��o
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = downSprite;
        }
        else if (movement.x != 0)
        {
            spriteRenderer.sprite = walkSprite;

            // Inverter sprite quando andar para a esquerda
            if (movement.x < 0)
                spriteRenderer.flipX = true;
            else if (movement.x > 0)
                spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }

    void FixedUpdate()
    {
        // Movimenta��o com linear velocity
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
}
