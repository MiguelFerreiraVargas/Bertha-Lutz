using UnityEngine;

public class InteragirComPainel : MonoBehaviour
{
    public GameObject painel;  // O painel que será mostrado/ocultado

    void Start()
    {
        if (painel != null)
        {
            painel.SetActive(false);  // Inicializa o painel como invisível
        }
        else
        {
            Debug.LogError("O painel não está atribuído no Inspector!");
        }
    }

    void Update()
    {
        // Verifica se a tecla E foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Alterna a visibilidade do painel
            if (painel != null)
            {
                painel.SetActive(!painel.activeSelf);
                Debug.Log("Painel foi " + (painel.activeSelf ? "aberto" : "fechado"));
            }
        }

        // Verifica se a tecla ESC foi pressionada e oculta o painel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (painel != null)
            {
                painel.SetActive(false);  // Fecha o painel
                Debug.Log("Painel fechado com ESC");
            }
        }
    }
}