using UnityEngine;

public class EnemySimples : MonoBehaviour
{
    [Header("Configurações do Inimigo")]
    public float speed = 2f;              // Velocidade de movimento
    public float danoSanidade = 10f;      // Dano causado ao encostar no player
    public float distanciaDeDeteccao = 10f; // Distância máxima para detectar o player

    private Transform player;
    private HideSystem hideSystem;

    void Start()
    {
        // Acha o player pela tag
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            hideSystem = playerObj.GetComponent<HideSystem>();
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com tag 'Player' encontrado na cena!");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Se o player estiver escondido, o inimigo ignora
        if (hideSystem != null && hideSystem.estaEscondido)
            return;

        // Calcula distância até o player
        float distancia = Vector2.Distance(transform.position, player.position);

        // Se estiver perto o suficiente, segue o player
        if (distancia <= distanciaDeDeteccao)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    // Detecta colisão com o player (usar Collider2D com Is Trigger marcado)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Se o player estiver escondido, não causa dano
            HideSystem hide = collision.GetComponent<HideSystem>();
            if (hide != null && hide.estaEscondido)
                return;

            // Reduz sanidade
            BarraDeVida barra = collision.GetComponent<BarraDeVida>();
            if (barra != null)
            {
                barra.sanity -= danoSanidade;
                barra.sanity = Mathf.Clamp(barra.sanity, 0, barra.sanityMax);
                Debug.Log("🧠 Player perdeu sanidade! Sanidade atual: " + barra.sanity);
            }

            // Destroi o inimigo após causar dano
            Destroy(gameObject);
        }
    }
}
