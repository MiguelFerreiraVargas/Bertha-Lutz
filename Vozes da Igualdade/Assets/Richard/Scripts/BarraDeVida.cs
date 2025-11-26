using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public static BarraDeVida instance;

    [Header("UI (preencha só na primeira cena)")]
    public Slider slider;
    public TMP_Text contadorSanidade;
    public GameObject feedbackVisual;

    [Header("Sanidade")]
    public float sanity = 100f;
    public float sanityMax = 100f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Quando trocar de cena → reconectar UI
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        AtualizarUI();
    }

    // Quando uma nova cena carrega → buscar o novo Slider/TMP automaticamente
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        EncontrarNovosElementosUI();
        AtualizarUI();
    }

    void Update()
    {
        sanity = Mathf.Clamp(sanity, 0, sanityMax);

        AtualizarUI();
    }

    void AtualizarUI()
    {
        if (slider != null)
        {
            slider.maxValue = sanityMax;
            slider.value = sanity;
        }

        if (contadorSanidade != null)
        {
            contadorSanidade.text = $"{sanity}/{sanityMax}";
        }

        if (feedbackVisual != null)
        {
            feedbackVisual.SetActive(sanity < 50);
        }
    }

    // Procura automaticamente o Slider, TMP e Feedback da cena nova
    void EncontrarNovosElementosUI()
    {
        slider = GameObject.Find("BarraDeSanidade")?.GetComponent<Slider>();
        contadorSanidade = GameObject.Find("TextoSanidade")?.GetComponent<TMP_Text>();
        feedbackVisual = GameObject.Find("FeedbackSanidade");
        foreach (var go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (go.name == "FeedbackSanidade")   // nome do objeto da UI
                feedbackVisual = go;
        }
    }

    public void PerderSanidade(float valor)
    {
        sanity -= valor;
        AtualizarUI();
    }

    public void GanharSanidade(float valor)
    {
        sanity += valor;
        AtualizarUI();
    }
}
