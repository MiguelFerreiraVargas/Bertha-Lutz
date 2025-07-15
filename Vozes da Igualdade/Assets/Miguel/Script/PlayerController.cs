using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject cuboGrande;    // Player em pé
    public GameObject cuboAgachado;  // Player agachado

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool _isCrouching;       // Interno

    public bool isCrouching => _isCrouching; // Público para leitura externa (ex: inimigo)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetCrouch(false);
    }

    void Update()
    {
        // Verifica entrada para agachar
        bool crouchInput = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        SetCrouch(crouchInput);

        // Movimento lateral
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Verifica se está no chão
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Pulo (só se no chão e não agachado)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !_isCrouching)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void SetCrouch(bool crouch)
    {
        _isCrouching = crouch;
        cuboGrande.SetActive(!crouch);
        cuboAgachado.SetActive(crouch);
    }
}