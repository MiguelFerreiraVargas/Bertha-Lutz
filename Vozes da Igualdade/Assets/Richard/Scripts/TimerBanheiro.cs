using UnityEngine;
using TMPro;

public class TimerPuzzle : MonoBehaviour
{
    public float tempo = 90f; // 1 minuto e 30s
    public bool timerAtivo = true;

    public TMP_Text textoTimer;

    public bool tempoAcabou = false;

    void Update()
    {
        if (!timerAtivo) return;

        tempo -= Time.deltaTime;

        if (tempo <= 0)
        {
            tempo = 0;
            timerAtivo = false;
            tempoAcabou = true;
        }

        int minutos = Mathf.FloorToInt(tempo / 60);
        int segundos = Mathf.FloorToInt(tempo % 60);
        textoTimer.text = $"{minutos:00}:{segundos:00}";
    }
}
