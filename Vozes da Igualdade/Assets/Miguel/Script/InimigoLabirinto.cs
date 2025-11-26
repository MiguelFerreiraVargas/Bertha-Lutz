using UnityEngine;

public class InimigoPacman : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidadeNormal = 2f;
    public float velocidadePerseguindo = 3.5f;

    [Header("Detecção do Player")]
    public float distanciaDeVisao = 6f;

    [Header("Dano")]
    public int dano = 5;          // SEMPRE 5
    public float intervaloDano = 1f; // a cada 1 segundo

    private Transform player;
    private Vector2 direcaoAleatoria;
    private float tempoTrocarDirecao = 2f;
    private float contadorDirecao = 0f;
    private float contadorDano = 0f;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        TrocarDirecaoAleatoria();
    }

    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaDeVisao)
            PerseguirPlayer();
        else
            AndarAleatorio();
    }

    void PerseguirPlayer()
    {
        Vector2 direcao = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direcao * velocidadePerseguindo * Time.deltaTime);
    }

    void AndarAleatorio()
    {
        contadorDirecao += Time.deltaTime;

        if (contadorDirecao >= tempoTrocarDirecao)
            TrocarDirecaoAleatoria();

        transform.position += (Vector3)(direcaoAleatoria * velocidadeNormal * Time.deltaTime);
    }

    void TrocarDirecaoAleatoria()
    {
        direcaoAleatoria = Random.insideUnitCircle.normalized;
        contadorDirecao = 0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            contadorDano += Time.deltaTime;

            if (contadorDano >= intervaloDano)
            {
                BarraDeVida.instance.PerderSanidade(dano);
                contadorDano = 0f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            contadorDano = 0f;
    }
}
