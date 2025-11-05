using UnityEngine;

public class HideSystem : MonoBehaviour
{
    [Header("Configurações de Esconderijo")]
    public KeyCode teclaEsconder = KeyCode.E; // tecla para entrar/sair do esconderijo
    public bool estaEscondido = false;        // indica se o player está escondido
    private Collider2D esconderijoAtual;      // referência ao esconderijo mais próximo
    private SpriteRenderer spriteRenderer;    // para esconder o visual do player

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(teclaEsconder) && esconderijoAtual != null)
        {
            if (!estaEscondido)
                EntrarNoEsconderijo();
            else
                SairDoEsconderijo();
        }
    }

    void EntrarNoEsconderijo()
    {
        estaEscondido = true;
        spriteRenderer.enabled = false; // "some" visualmente
        Debug.Log("Player entrou no esconderijo!");
    }

    void SairDoEsconderijo()
    {
        estaEscondido = false;
        spriteRenderer.enabled = true;
        Debug.Log("Player saiu do esconderijo!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Esconderijo"))
        {
            esconderijoAtual = collision;
            Debug.Log("Pode se esconder aqui. Pressione E.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == esconderijoAtual)
        {
            esconderijoAtual = null;
        }
    }
}
