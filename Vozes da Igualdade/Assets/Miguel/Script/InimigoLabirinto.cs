using UnityEngine;

public class InimigoCimaBaixo : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 2f;
    public Vector2 direcao = Vector2.up; // Começa indo pra cima - pode trocar no inspetor

    [Header("Dano")]
    public int dano = 10;

    void Update()
    {
        // Movimento simples para cima/baixo
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se bater no limite de movimento, inverte direção
        if (collision.CompareTag("Limite"))
        {
            direcao *= -1; // cima ↔ baixo
        }

        // Se encostar no player
        if (collision.CompareTag("Player"))
        {
            BarraDeVida.instance.PerderSanidade(dano);

            // Some da cena
            Destroy(gameObject);
        }
    }
}
