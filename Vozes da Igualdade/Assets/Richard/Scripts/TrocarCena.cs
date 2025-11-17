using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string Banheiro;
    bool pode = false;

    void Update()
    {
        if (pode && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(Banheiro);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
            pode = true;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
            pode = false;
    }
}
