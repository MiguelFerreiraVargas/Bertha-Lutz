using UnityEngine;

public class EnemieFollowing : MonoBehaviour
{
    [SerializeField] private float speed = 9;

    [SerializeField] private Transform target;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    // Este m�todo � chamado automaticamente quando o colisor do inimigo (Is Trigger) colide com outro objeto.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido � o jogador (pela sua tag).
        if (other.gameObject.CompareTag("Player"))
        {
            // Pega o script de barra de vida do jogador.
            Sanidade playerHealth = other.gameObject.GetComponent<Sanidade>();

            // Verifica se o script existe para evitar erros.
            if (playerHealth != null)
            {
                // Chama o m�todo para causar dano ao jogador.
                playerHealth.TakeDamage(10); // Causa 10 de dano, voc� pode ajustar esse valor.
            }

            // Destr�i o inimigo para que ele suma da tela ap�s a colis�o.
            Destroy(gameObject);
        }
    }
}