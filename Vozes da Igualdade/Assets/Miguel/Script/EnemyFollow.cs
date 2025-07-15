using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float followRange = 5f;

    private PlayerController playerController;

    void Start()
    {
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (player == null || playerController == null) return;

        // Se o jogador estiver agachado, não seguir
        if (playerController.isCrouching) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < followRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }
}