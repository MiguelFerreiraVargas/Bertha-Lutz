using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
    public string menu1 = "Menu";
    public string sceneName = "TaxiTeleport"; // Nome da cena a carregar
    private bool hasLoaded = false; // Evita múltiplos loads

    public void menu (string menu1)
    {
        SceneManager.LoadScene(menu1); 
    }
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