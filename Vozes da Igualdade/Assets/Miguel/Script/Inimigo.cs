using UnityEngine;
using UnityEngine.AI;

public class EnemyAI2D : MonoBehaviour
{
    public float damageAmount = 20f; // quanto de dano causa
    public float deathDelay = 0.5f;  // tempo antes de "morrer" ao tocar no player

    private Transform player;
    private NavMeshAgent agent;
    private Sanidade playerHealth;
    private HideInside hideScript;
    private bool isDead = false;

    void Start()
    {
        // Pega referência do player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<Sanidade>();
            hideScript = playerObj.GetComponent<HideInside>();
        }

        agent = GetComponent<NavMeshAgent>();

        // Ajustes obrigatórios pra 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Inimigo "morre"
            StartCoroutine(Die());
        }
    }

    private System.Collections.IEnumerator Die()
    {
        isDead = true;
        agent.isStopped = true;

        // Aqui você pode colocar animação, som, etc.
        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }
}