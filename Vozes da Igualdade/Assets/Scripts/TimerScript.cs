using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TMP_Text firstNote;
    [SerializeField] TMP_Text timerText;

    float timerRemaining = 60f;
    bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timerRemaining > 0)
            {
                timerRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timerRemaining);
                ShowNotes(); // Verifica se a nota deve aparecer
            }
            else
            {
                timerRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(0);
                firstNote.gameObject.SetActive(false); // desativa ao fim
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ShowNotes()
    {
        // Mostra a nota entre 45s e 35s
        if (timerRemaining < 45 && timerRemaining > 35)
        {
            firstNote.gameObject.SetActive(true);
        }
        else
        {
            firstNote.gameObject.SetActive(false);
        }
    }
}
