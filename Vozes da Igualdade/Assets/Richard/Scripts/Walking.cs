using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Som de Passos")]
    public AudioSource audioPassos;
    public float intervaloPassos = 0.4f;
    private float passoTimer = 0f;

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);

        // 🔊 Som de passos
        if (movement.magnitude > 0.1f)
        {
            passoTimer -= Time.deltaTime;
            if (passoTimer <= 0f)
            {
                if (!audioPassos.isPlaying)
                    audioPassos.Play();
                passoTimer = intervaloPassos;
            }
        }
    }
}
