using UnityEngine;

public class PuzzleTimer : MonoBehaviour
{
    public float tempoMaximo = 90f;
    private float tempoRestante;

    private bool timerAtivo = false;
    private bool danoAtivo = false;

    public BarraDeVida barraDeVida;

    void Update()
    {
        if (timerAtivo)
        {
            tempoRestante -= Time.deltaTime;

            if (tempoRestante <= 0)
            {
                timerAtivo = false;
                danoAtivo = true;
            }
        }

        if (danoAtivo)
        {
            barraDeVida.PerderSanidade(10f * Time.deltaTime);
        }
    }

    public void Iniciar()
    {
        tempoRestante = tempoMaximo;
        timerAtivo = true;
        danoAtivo = false;
    }

    public void Parar()
    {
        timerAtivo = false;
        danoAtivo = false;
    }
}
