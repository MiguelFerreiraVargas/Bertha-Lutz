using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    private string labirintoScene = "Labirinto"; // coloque o nome EXATO da cena

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Se a nova cena NÃO for o Labirinto → destrói o Player
        if (scene.name != labirintoScene)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Destroy(player);
                Debug.Log("Player destruído ao sair do Labirinto.");
            }
        }
    }
}