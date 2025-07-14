using UnityEngine;
using UnityEngine.SceneManagement;  // Necess�rio para carregar cenas

public class StartScreen : MonoBehaviour
{
    // Fun��o chamada quando o bot�o � clicado
    public void StartGame()
    {
        // Carrega a cena do jogo (certifique-se de que a cena "Game" est� adicionada nas configura��es do build)
        SceneManager.LoadScene("Game");
    }
}