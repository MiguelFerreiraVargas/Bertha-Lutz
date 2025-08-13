using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float direcao;
    private Rigidbody2D rb;
    private bool isJumping;
    [SerializeField] private float jumpForce = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    void Update()
    {
        // Movimento horizontal
        direcao = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(direcao * speed, rb.linearVelocity.y);

        // Virar o sprite
        if (direcao > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (direcao < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
        }
    }

    // Detectar se encostou no ch�o
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}