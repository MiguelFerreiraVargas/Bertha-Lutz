using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider; 
    public float health = 100f;// float pois o jogador não se movimenta no eixo x 0.1 unidades no trecho de um frame
    public float healthMax = 100f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //botao esquerdo 
            // down se refere a cada clique do mouse 
        {
            health += 5; //aumenta 5 pontos de vida
        }
        else if (Input.GetMouseButtonDown(1)) // botao direito 
        { 
            health -= 10; //diminui dez pontos de vida 
        }
        health = Mathf.Clamp(health, 0, healthMax);// limita a vida para menos q 0 
        slider.value = health;
        slider.maxValue = healthMax;
    }
}
