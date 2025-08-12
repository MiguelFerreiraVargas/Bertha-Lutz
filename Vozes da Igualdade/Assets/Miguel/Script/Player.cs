using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float direcao;
    private Rigidbody2D rb;
    private bool isJumping;
    [SerializeField] private float jumpForce = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(direcao * speed, rb.linearVelocity.y);

        if (direcao > 0 )
        {
            transform.localScale = new Vector2(1f,1f);
        }

        else if (direcao < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        if (Input.GetButtonDown("Jump")) && isJumping = false;
        {
            rb.linearVelocityY = jumpForce;
            isJumping = true;
        }
        
    }
}
