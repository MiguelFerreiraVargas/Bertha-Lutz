using UnityEngine;
using TMPro;

public class TimerBanheiro : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float tempoMaximo = 90f;
    private float tempoAtual;
    private bool ativo = false;

    public BarraDeVida barraDeVida;
    public float danoPorSegundo = 10f;

    void Start()
    {
        tempoAtual = tempoMaximo;
        timerText.text = "01:30";
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!ativo) return;

        if (tempoAtual > 0)
        {
            tempoAtual -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempoAtual / 60);
            int segundos = Mathf.FloorToInt(tempoAtual % 60);

            timerText.text = $"{minutos:00}:{segundos:00}";
        }
        else
        {
            barraDeVida.PerderSanidade(danoPorSegundo * Time.deltaTime);
        }
    }

    public void IniciarTimer()
    {
        tempoAtual = tempoMaximo;
        ativo = true;
        timerText.gameObject.SetActive(true);
    }

    public void PararTimer()
    {
        ativo = false;
        timerText.gameObject.SetActive(false);
    }
}
