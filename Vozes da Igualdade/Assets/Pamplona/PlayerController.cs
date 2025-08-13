using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 3f;

    [Header("Sprites do Personagem")]
    public Sprite idleSprite;
    public Sprite walkSprite;
    public Sprite jumpSprite;
    public Sprite crouchSprite;

    [Header("Ground Check")]
    public Transform groundCheck;            // um empty no pé do player
    public float groundCheckRadius = 0.12f;
    public LayerMask groundLayer;            // selecione a layer "Ground" no inspector

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private float _moveInput;
    private bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Garantir que a rotação não vire o player
        if (_rb != null)
        {
            _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            _rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // checa se está no chão
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // movimento horizontal
        _moveInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            _moveInput = -1f;
            _spriteRenderer.sprite = walkSprite;
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _moveInput = 1f;
            _spriteRenderer.sprite = walkSprite;
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _moveInput = 0f;
            _spriteRenderer.sprite = crouchSprite;
        }
        else
        {
            // no ar, mantém sprite de pulo
            if (!_isGrounded)
                _spriteRenderer.sprite = jumpSprite;
            else
                _spriteRenderer.sprite = idleSprite;
        }

        // pular — só se estiver no chão
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
            _spriteRenderer.sprite = jumpSprite;
        }
    }

    void FixedUpdate()
    {
        // aplica movimento horizontal preservando velocidade vertical
        _rb.linearVelocity = new Vector2(_moveInput * moveSpeed, _rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
