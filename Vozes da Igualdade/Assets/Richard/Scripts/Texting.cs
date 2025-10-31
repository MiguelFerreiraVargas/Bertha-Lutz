using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Texting : MonoBehaviour
{
    public string sceneName; // nome da cena a carregar
    private bool hasLoaded = false; // evita m�ltiplos loads

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Porta") && !hasLoaded)
        {
            hasLoaded = true;
            SceneManager.LoadScene("Richard");
        }
    }
    private IEnumerator LoadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Richard");
    }
}