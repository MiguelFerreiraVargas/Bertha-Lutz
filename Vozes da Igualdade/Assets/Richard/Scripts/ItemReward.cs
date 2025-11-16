
using UnityEngine;

public class ItemReward : MonoBehaviour
{
    [Header("Inimigo para Ativar")]
    public GameObject inimigo;  // Arraste o inimigo aqui no Inspector

    [Header("Configurações")]
    public bool destruirAposColeta = true;
    public ParticleSystem efeitoColeta;
    public AudioClip somColeta;

    private bool foiColetado = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (foiColetado) return;

        if (other.CompareTag("Player"))
        {
            ColetarItem();
        }
    }

    void ColetarItem()
    {
        foiColetado = true;
        Debug.Log("🎁 Item reward coletado!");

        // Ativa o inimigo
        if (inimigo != null)
        {
            inimigo.SetActive(true);
            Debug.Log("👹 Inimigo ativado: " + inimigo.name);

            // Se o inimigo tem um script com método de ativação, chama ele
            MonoBehaviour[] scripts = inimigo.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                // Tenta chamar métodos comuns de ativação
                if (script.GetType().GetMethod("IniciarPerseguicao") != null)
                {
                    script.Invoke("IniciarPerseguicao", 0f);
                }
                else if (script.GetType().GetMethod("AtivarInimigo") != null)
                {
                    script.Invoke("AtivarInimigo", 0f);
                }
                else if (script.GetType().GetMethod("StartChasing") != null)
                {
                    script.Invoke("StartChasing", 0f);
                }
            }
        }
        else
        {
            Debug.LogWarning("❌ Nenhum inimigo atribuído no ItemReward");
        }

        // Efeitos visuais e sonoros
        if (efeitoColeta != null)
        {
            Instantiate(efeitoColeta, transform.position, Quaternion.identity);
        }

        if (somColeta != null)
        {
            AudioSource.PlayClipAtPoint(somColeta, transform.position);
        }

        // Destroi ou desativa o item
        if (destruirAposColeta)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Método para debug no Editor
    [ContextMenu("Testar Coleta")]
    void TestarColeta()
    {
        ColetarItem();
    }
}
