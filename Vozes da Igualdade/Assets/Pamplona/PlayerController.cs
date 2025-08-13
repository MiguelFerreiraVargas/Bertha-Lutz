using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configura��es de Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Sprites do Personagem")]
    public Sprite idleSprite;   // Parado
    public Sprite walkSprite;   // Andando
    public Sprite jumpSprite;   // Pulando
    public Sprite crouchSprite; // Agachado

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _movement;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = 0f;

        // Andar para a esquerda
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            _spriteRenderer.sprite = walkSprite;
            _spriteRenderer.flipX = true;
        }
        // Andar para a direita
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
            _spriteRenderer.sprite = walkSprite;
            _spriteRenderer.flipX = false;
        }
        // Agachar
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput = 0f;
            _spriteRenderer.sprite = crouchSprite;
        }
        // Pular
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _spriteRenderer.sprite = jumpSprite;
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }
        // Parado
        else
        {
            moveInput = 0f;
            _spriteRenderer.sprite = idleSprite;
        }

        _movement = new Vector2(moveInput, 0);
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_movement.x * moveSpeed, _rb.linearVelocity.y);
    }
}
