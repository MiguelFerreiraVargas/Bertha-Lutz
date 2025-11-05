using UnityEngine;

public class HideSystem : MonoBehaviour
{
    [Header("Configurações de Esconderijo")]
    public KeyCode teclaEsconder = KeyCode.E;
    public bool estaEscondido = false;
    private Collider2D esconderijoAtual;
    private SpriteRenderer spriteRenderer;

    private MonoBehaviour movimentoScript; // referência ao script de movimento

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movimentoScript = GetComponent<PlayerMovement>();
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
        spriteRenderer.enabled = false;

        if (movimentoScript != null)
            movimentoScript.enabled = false; // desativa o movimento

        Debug.Log("Player entrou no esconderijo!");
    }

    void SairDoEsconderijo()
    {
        estaEscondido = false;
        spriteRenderer.enabled = true;

        if (movimentoScript != null)
            movimentoScript.enabled = true; // reativa o movimento

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