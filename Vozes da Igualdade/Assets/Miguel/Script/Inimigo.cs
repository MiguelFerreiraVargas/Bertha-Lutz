using UnityEngine;

public class EnemySimples : MonoBehaviour
{
    [Header("Configurações do Inimigo")]
    public float speedPatrulha = 2f;          // Velocidade enquanto patrulha
    public float speedPerseguindo = 3.5f;     // Velocidade enquanto persegue
    public float danoSanidade = 10f;          // Dano causado ao encostar no player
    public float distanciaDeDeteccao = 8f;    // Distância máxima para detectar o player

    [Header("Pontos de Patrulha")]
    public Transform[] pontosDePatrulha;      // Lista de pontos (adicione no Inspector)
    private int pontoAtual = 0;

    private Transform player;
    private HideSystem hideSystem;
    private bool perseguindo = false;

    void Start()
    {
        // Acha o player
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            hideSystem = playerObj.GetComponent<HideSystem>();
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com tag 'Player' encontrado!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Se o player estiver escondido, para de perseguir e volta a patrulhar
        if (hideSystem != null && hideSystem.estaEscondido)
        {
            perseguindo = false;
            Patrulhar();
            return;
        }

        // Calcula distância até o player
        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaDeDeteccao)
        {
            perseguindo = true;
        }
        else if (perseguindo && distancia > distanciaDeDeteccao * 1.5f)
        {
            // Se o player fugir muito, volta a patrulhar
            perseguindo = false;
        }

        if (perseguindo)
            Perseguir();
        else
            Patrulhar();
    }

    void Patrulhar()
    {
        if (pontosDePatrulha.Length == 0) return;

        Transform alvo = pontosDePatrulha[pontoAtual];
        transform.position = Vector2.MoveTowards(
            transform.position,
            alvo.position,
            speedPatrulha * Time.deltaTime
        );

        // Quando chega no ponto atual, vai para o próximo
        if (Vector2.Distance(transform.position, alvo.position) < 0.1f)
        {
            pontoAtual = (pontoAtual + 1) % pontosDePatrulha.Length;
        }
    }

    void Perseguir()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speedPerseguindo * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        HideSystem hide = collision.GetComponent<HideSystem>();
        if (hide != null && hide.estaEscondido)
            return;

        BarraDeVida barra = collision.GetComponent<BarraDeVida>();
        if (barra != null)
        {
            barra.sanity -= danoSanidade;
            barra.sanity = Mathf.Clamp(barra.sanity, 0, barra.sanityMax);
            Debug.Log(" Player perdeu sanidade! Sanidade atual: " + barra.sanity);
        }

        Destroy(gameObject);
    }
}
