using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI_2025 : MonoBehaviour
{
    public enum EnemyState { Chasing, Patrolling, Searching }

    [Header("Configurações de Detecção")]
    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 1.5f;
    public float detectionRange = 5f;
    public float searchTime = 3f;

    [Header("Waypoints de Patrulha")]
    public Transform[] waypoints;

    private EnemyState currentState = EnemyState.Patrolling;
    private Transform player;
    private HideInside playerHideScript;
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private float searchTimer = 0f;
    private Vector3 lastKnownPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHideScript = player.GetComponent<HideInside>();

        // Configurações importantes para 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartPatrol();
    }

    void Update()
    {
        if (player == null) return;

        bool playerIsHidden = playerHideScript != null && playerHideScript.isHidden;

        switch (currentState)
        {
            case EnemyState.Chasing:
                HandleChaseState(playerIsHidden);
                break;

            case EnemyState.Patrolling:
                HandlePatrolState(playerIsHidden);
                break;

            case EnemyState.Searching:
                HandleSearchState();
                break;
        }
    }

    void HandleChaseState(bool playerIsHidden)
    {
        if (playerIsHidden)
        {
            // Player se escondeu, ir para última posição conhecida
            lastKnownPosition = player.position;
            SwitchToSearch();
        }
        else
        {
            // Continuar perseguindo
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
    }

    void HandlePatrolState(bool playerIsHidden)
    {
        if (!playerIsHidden && IsPlayerInRange())
        {
            SwitchToChase();
        }
        else
        {
            Patrol();
        }
    }

    void HandleSearchState()
    {
        searchTimer -= Time.deltaTime;

        if (searchTimer <= 0f)
        {
            // Tempo de busca acabou, voltar a patrulhar
            SwitchToPatrol();
        }
        else if (agent.remainingDistance < 0.5f)
        {
            // Chegou na última posição, procurar aleatoriamente
            SearchRandomly();
        }
    }

    bool IsPlayerInRange()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        return distance <= detectionRange;
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        agent.speed = patrolSpeed;
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        // Verificar se chegou no waypoint
        if (agent.remainingDistance < 0.3f && !agent.pathPending)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void SearchRandomly()
    {
        // Busca em pontos aleatórios ao redor da última posição
        Vector2 randomPoint = lastKnownPosition + (Vector3)Random.insideUnitCircle * 2f;
        agent.SetDestination(randomPoint);
    }

    void SwitchToChase()
    {
        currentState = EnemyState.Chasing;
        agent.speed = chaseSpeed;
        Debug.Log("Inimigo: Perseguindo player!");
    }

    void SwitchToPatrol()
    {
        currentState = EnemyState.Patrolling;
        agent.speed = patrolSpeed;
        StartPatrol();
        Debug.Log("Inimigo: Voltando a patrulhar");
    }

    void SwitchToSearch()
    {
        currentState = EnemyState.Searching;
        agent.speed = patrolSpeed;
        searchTimer = searchTime;
        agent.SetDestination(lastKnownPosition);
        Debug.Log("Inimigo: Procurando na última posição");
    }

    void StartPatrol()
    {
        if (waypoints.Length > 0)
        {
            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Alcance de detecção
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Estado atual
        Gizmos.color = currentState switch
        {
            EnemyState.Chasing => Color.red,
            EnemyState.Patrolling => Color.blue,
            EnemyState.Searching => Color.yellow,
            _ => Color.white
        };
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}