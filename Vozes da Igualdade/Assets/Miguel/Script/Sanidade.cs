using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{
    public Slider slider;
    public float health = 100f;
    public float healthMax = 100f;

    // Start é chamado uma vez antes da primeira execução de Update
    void Start()
    {
        // Define os valores iniciais da barra de vida.
        slider.maxValue = healthMax;
        slider.value = health;
    }

    // Método público para receber dano de outros scripts.
    public void TakeDamage(float amount)
    {
        health -= amount; // Diminui a vida pelo valor recebido.
        UpdateHealthBar(); // Atualiza a barra de vida.
    }

    // Método público para curar (caso precise em outro script).
    public void Heal(float amount)
    {
        health += amount;
        UpdateHealthBar();
    }

    // Método para atualizar a barra de vida, evitando duplicação de código.
    private void UpdateHealthBar()
    {
        health = Mathf.Clamp(health, 0, healthMax); // Garante que a vida não vai além dos limites.
        slider.value = health; // Atualiza o slider.
    }

    private void Update()
    {
        // Remove os testes de botão de mouse para que a vida seja controlada
        // apenas pelo sistema de colisão e outros eventos do jogo.

        // Exemplo: se você quiser ver a vida mudar sem o inimigo, pode usar um código como este:
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Heal(5);
        // }
        // else if (Input.GetMouseButtonDown(1))
        // {
        //     TakeDamage(10);
        // }

        // Note que o método UpdateHealthBar já é chamado nas funções de dano e cura,
        // então não precisa chamar aqui a cada frame.
    }
}