using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
    public string sceneName = "Pamplona"; // Nome da cena a carregar
    private bool hasLoaded = false; // Evita múltiplos loads

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasLoaded)
        {
            hasLoaded = true;
            StartCoroutine(LoadAfterDelay(1f)); // chama a coroutine com delay de 1 segundo
        }
    }

    private IEnumerator LoadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}