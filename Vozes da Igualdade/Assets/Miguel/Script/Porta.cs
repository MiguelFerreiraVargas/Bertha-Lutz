using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaCena : MonoBehaviour
{
    [Header("Nome da Cena Para Carregar")]
    public string nomeDaCena;

    [Header("Configuração")]
    public KeyCode teclaInteracao = KeyCode.E;
    public GameObject painelInteracao; // UI "Aperte E"

    private bool podeInteragir = false;

    void Start()
    {
        if (painelInteracao != null)
            painelInteracao.SetActive(false);
    }

    void Update()
    {
        if (podeInteragir && Input.GetKeyDown(teclaInteracao))
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = true;
            if (painelInteracao != null)
                painelInteracao.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = false;
            if (painelInteracao != null)
                painelInteracao.SetActive(false);
        }
    }
}
