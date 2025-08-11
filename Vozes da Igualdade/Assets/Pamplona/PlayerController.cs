using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento lateral
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        // Pulo
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Agachar
        if (Input.GetKey(KeyCode.S))
        {
            // Aqui você pode colocar lógica de agachar (ex: mudar tamanho ou sprite)
            transform.localScale = new Vector3(1f, 0.5f, 1f); // abaixa o tamanho
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // volta ao normal
        }
    }

    void FixedUpdate()
    {
        // Movimenta no eixo X e mantém velocidade Y da física
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}