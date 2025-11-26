using UnityEngine;

public class SairJogo : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Saiu do jogo!"); // Só aparece no editor
        Application.Quit();         // Fecha quando for buildado
    }
}
