using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadscene : MonoBehaviour
{
    public string sceneName; // nome da cena a carregar
    private bool hasLoaded = false; // evita múltiplos loads

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Porta") && !hasLoaded)
        {
            hasLoaded = true;
            SceneManager.LoadScene("Pamplona");
        }
    }
    private IEnumerator LoadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Pamplona");
    }
}