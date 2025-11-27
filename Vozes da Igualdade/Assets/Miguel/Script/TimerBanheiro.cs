using UnityEngine;
using TMPro;

public class TimerBanheiro : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float tempoMaximo = 30f;
    private float tempoAtual;
    private bool ativo = false;

    public BarraDeVida barraDeVida;
    public int danoPorSegundo = 10;

    private float contadorDano = 0f;

    private bool acabou = false;
    private float blinkTimer = 0f;

    void Start()
    {
        tempoAtual = tempoMaximo;
        timerText.text = "00:30";
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        // GARANTE QUE SEMPRE ACHE A BARRA DE VIDA
        if (barraDeVida == null)
        {
            barraDeVida = BarraDeVida.instance;
            // se ainda não existe, espera o próximo frame
            if (barraDeVida == null)
                return;
        }

        if (!ativo) return;

        // TIMER TERMINADO
        if (acabou)
        {
            PiscarTexto();
            CausarDano();
            return;
        }

        // TIMER RODANDO
        if (tempoAtual > 0)
        {
            tempoAtual -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempoAtual / 60);
            int segundos = Mathf.FloorToInt(tempoAtual % 60);

            timerText.text = $"{minutos:00}:{segundos:00}";
        }

        if (tempoAtual <= 0 && !acabou)
        {
            tempoAtual = 0;
            timerText.text = "00:00";
            acabou = true;

            timerText.color = Color.red;
        }
    }

    void CausarDano()
    {
        contadorDano += Time.deltaTime;

        if (contadorDano >= 1f)
        {
            barraDeVida.PerderSanidade(danoPorSegundo);
            contadorDano = 0f;
        }
    }

    void PiscarTexto()
    {
        blinkTimer += Time.deltaTime;

        if (blinkTimer >= 0.5f)
        {
            timerText.enabled = !timerText.enabled;
            blinkTimer = 0f;
        }
    }

    public void IniciarTimer()
    {
        ativo = true;
        acabou = false;
        tempoAtual = tempoMaximo;

        timerText.color = Color.white;
        timerText.enabled = true;
        timerText.gameObject.SetActive(true);
    }

    public void PararTimer()
    {
        ativo = false;
        timerText.gameObject.SetActive(false);
    }
}
