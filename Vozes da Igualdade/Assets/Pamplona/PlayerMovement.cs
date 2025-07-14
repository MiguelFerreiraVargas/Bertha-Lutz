using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento para os lados com A e D
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.A))
            moveDirection = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveDirection = 1f;

        // Usando linearVelocity no lugar de velocity
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Pulo com W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
