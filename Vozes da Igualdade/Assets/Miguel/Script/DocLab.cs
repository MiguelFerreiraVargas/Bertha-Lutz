using UnityEngine;
using UnityEngine.SceneManagement;

public class DocLab : MonoBehaviour
{
    [Header("Nome das Cenas Final")]
    public string CurtsceneFinalRuim;
    public string CutesceneFinalUM;
    private bool podePegar = false;

    private void Update()
    {
        if (podePegar && Input.GetKeyDown(KeyCode.E))
        {
            PegarDocumento();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            podePegar = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            podePegar = false;
    }

    void PegarDocumento()
    {
        if (BarraDeVida.instance == null)
        {
            Debug.LogError("ERRO: BarraDeVida.instance está NULL.");
            return;
        }

        float sanidade = BarraDeVida.instance.sanity;
        Debug.Log("Sanidade atual: " + sanidade);

        if (sanidade < 50)
        {
            Debug.Log("Final RUIM → carregando: " + CurtsceneFinalRuim);
            SceneManager.LoadScene(CurtsceneFinalRuim);
        }
        else
        {
            Debug.Log("Final BOM → carregando: " + CutesceneFinalUM);
            SceneManager.LoadScene(CutesceneFinalUM);
        }
    }
}
