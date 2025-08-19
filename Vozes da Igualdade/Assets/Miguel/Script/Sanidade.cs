using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{
    public Slider slider;
    public float health = 100f;
    public float healthMax = 100f;

    // Start � chamado uma vez antes da primeira execu��o de Update
    void Start()
    {
        // Define os valores iniciais da barra de vida.
        slider.maxValue = healthMax;
        slider.value = health;
    }

    // M�todo p�blico para receber dano de outros scripts.
    public void TakeDamage(float amount)
    {
        health -= amount; // Diminui a vida pelo valor recebido.
        UpdateHealthBar(); // Atualiza a barra de vida.
    }

    // M�todo p�blico para curar (caso precise em outro script).
    public void Heal(float amount)
    {
        health += amount;
        UpdateHealthBar();
    }

    // M�todo para atualizar a barra de vida, evitando duplica��o de c�digo.
    private void UpdateHealthBar()
    {
        health = Mathf.Clamp(health, 0, healthMax); // Garante que a vida n�o vai al�m dos limites.
        slider.value = health; // Atualiza o slider.
    }

    private void Update()
    {
        // Remove os testes de bot�o de mouse para que a vida seja controlada
        // apenas pelo sistema de colis�o e outros eventos do jogo.

        // Exemplo: se voc� quiser ver a vida mudar sem o inimigo, pode usar um c�digo como este:
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Heal(5);
        // }
        // else if (Input.GetMouseButtonDown(1))
        // {
        //     TakeDamage(10);
        // }

        // Note que o m�todo UpdateHealthBar j� � chamado nas fun��es de dano e cura,
        // ent�o n�o precisa chamar aqui a cada frame.
    }
}