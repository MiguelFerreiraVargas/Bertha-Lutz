using UnityEngine;

public class DocumentoPickup : MonoBehaviour
{
    public GameObject portaFechada;
    public GameObject portaAberta;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desativa o documento (pegou automaticamente)
            gameObject.SetActive(false);

            // Troca as portas
            if (portaFechada != null) portaFechada.SetActive(false);
            if (portaAberta != null) portaAberta.SetActive(true);
        }
    }
}