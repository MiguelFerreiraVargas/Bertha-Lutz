using UnityEngine;
using UnityEngine.InputSystem; // Novo sistema de input, mas aqui você ainda usa o antigo (Input.GetAxis)

public class TesteAndando : MonoBehaviour
{
    public float moveSpeed = 5f;   // Velocidade do player
    private Rigidbody2D rb;        // Referência ao Rigidbody2D do player
    private Vector2 movement;      // Armazena o input do jogador

    void Start()
    {
        // Pega o componente Rigidbody2D do player quando o jogo começa
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Aqui só lemos o input do jogador (não movemos ainda)
        float x = Input.GetAxis("Horizontal"); // A/D ou setas → -1 a 1
        float y = Input.GetAxis("Vertical");   // W/S ou setas → -1 a 1

        movement = new Vector2(x, y).normalized; 
        // normalized garante que andar na diagonal não fique mais rápido
    }

    void FixedUpdate()
    {
        // Movimento aplicado no Rigidbody2D (ciclo da física)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}