using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHome : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.F;
    private bool isColliding = false;
    private KeyHome keyH;

    public string loadScene = "SampleScene";

    void Start()
    {
        // Versão nova (Unity 2023+)
        keyH = FindAnyObjectByType<KeyHome>();
    }

    void Update()
    {
        if (isColliding && Input.GetKeyDown(teclaInteracao))
        {
            if (keyH != null && keyH.keyHome)
            {
                SceneManager.LoadScene(loadScene);
            }
            else
            {
                Debug.Log("Você não tem a chave para entrar!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            Debug.Log("Pressione F para entrar na casa.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
