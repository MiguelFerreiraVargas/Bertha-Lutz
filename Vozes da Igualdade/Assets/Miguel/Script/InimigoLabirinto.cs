using UnityEngine;

public class InimigoPatrulha : MonoBehaviour
{
    public Transform pontoA;   // Coloque no Inspector
    public Transform pontoB;   // Coloque no Inspector
    public float velocidade = 2f;
    public int dano = 5;

    private Transform alvo;    // Para onde ele está indo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        alvo = pontoB; // começa indo para o ponto B
    }

    void FixedUpdate()
    {
        // Move até o ponto
        Vector2 novaPos = Vector2.MoveTowards(
            rb.position,
            alvo.position,
            velocidade * Time.fixedDeltaTime
        );

        rb.MovePosition(novaPos);

        // Quando chega perto do alvo → troca
        if (Vector2.Distance(transform.position, alvo.position) < 0.1f)
        {
            alvo = (alvo == pontoA ? pontoB : pontoA);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            BarraDeVida.instance.PerderSanidade(dano);
            Destroy(gameObject); // inimigo desaparece
        }
    }
}