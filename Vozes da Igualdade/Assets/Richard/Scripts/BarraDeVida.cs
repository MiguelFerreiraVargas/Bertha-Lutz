using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarraDeVida : MonoBehaviour
{
    public static BarraDeVida instance;

    public Slider slider;
    public float sanity = 100f;
    public float sanityMax = 100f;

    [SerializeField] TMP_Text contadorSanidade;
    [SerializeField] GameObject feedbackVisual;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // NÃO DESTRUIR AO TROCAR DE CENA
        }
        else
        {
            Destroy(gameObject);            // EVITA DUPLICAÇÃO
            return;
        }
    }

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

    public void PerderSanidade(float valor)
    {
        sanity -= valor;
    }

    public void GanharSanidade(float valor)
    {
        sanity += valor;
    }
}