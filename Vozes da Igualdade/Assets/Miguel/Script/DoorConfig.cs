using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorConfig : MonoBehaviour
{
    [Header("Configuração simples (troca sempre)")]
    public string playerTag = "Player";
    public string sceneToLoad = "Labirinto";

    bool hasLoaded = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasLoaded) return;
        if (!other.CompareTag(playerTag)) return;

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            hasLoaded = true;
            Debug.Log($"[DoorConfig] Player entrou em '{gameObject.name}', carregando cena '{sceneToLoad}'.");
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning($"[DoorConfig] sceneToLoad não configurada em '{gameObject.name}'.");
        }
    }
}