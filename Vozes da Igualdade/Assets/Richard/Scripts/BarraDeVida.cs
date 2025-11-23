using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public float sanity = 100f;
    public float sanityMax = 100f;

    [SerializeField] TMP_Text contadorSanidade;
    [SerializeField] GameObject feedbackVisual;

    void Start()
    {
        feedbackVisual.gameObject.SetActive(false);
        slider.maxValue = sanityMax;
        slider.value = sanity;
        contadorSanidade.text = $"{sanity}/{sanityMax}";
    }

    void Update()
    {
        sanity = Mathf.Clamp(sanity, 0, sanityMax);

        slider.value = sanity;
        contadorSanidade.text = $"{sanity}/{sanityMax}";

        if (sanity < 50)
            feedbackVisual.SetActive(true);
        else
            feedbackVisual.SetActive(false);
    }

    // Funções principais para dano e cura
    public void PerderSanidade(float valor)
    {
        sanity -= valor;
    }

    public void GanharSanidade(float valor)
    {
        sanity += valor;
    }
}