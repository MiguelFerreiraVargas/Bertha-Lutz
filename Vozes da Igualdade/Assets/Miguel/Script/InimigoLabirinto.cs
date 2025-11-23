using UnityEngine;

public class InimigoLabirinto : MonoBehaviour
{
    public float speed = 2f;
    public float chaseSpeed = 4f;

    public Transform pontoA;
    public Transform pontoB;

    private Transform destino;
    private Transform player;

    public bool playerDetectado = false;

    public BarraDeVida barraDeVida;

    void Start()
    {
        destino = pontoA;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerDetectado)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                chaseSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                destino.position,
                speed * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, destino.position) < 0.1f)
            {
                destino = destino == pontoA ? pontoB : pontoA;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            barraDeVida.PerderSanidade(40f * Time.deltaTime);
        }
    }
}
