using UnityEngine;

public class CallToObjects : MonoBehaviour
{
    [Header("Configurações")]
    public KeyCode teclaAtivar = KeyCode.F;   // Tecla que ativa o táxi
    public Transform jogadora;                // Referência ao player
    public Transform objetoAMover;            // O "táxi" que vai se mover
    public float velocidade = 5f;             // Velocidade do táxi
    public GameObject textoDica;              // Texto de dica na tela

    private bool playerNaArea = false;        // Indica se o player está na trigger
    private bool mover = false;               // Controla o movimento do táxi
    private TesteAndando jogadorScript;      // Script de movimento do player

    void Start()
    {
        if (textoDica != null)
            textoDica.SetActive(false);

        if (jogadora != null)
            jogadorScript = jogadora.GetComponent<TesteAndando>();
    }

    void Update()
    {
        // Ativa o movimento do táxi quando o player aperta a tecla
        if (playerNaArea && Input.GetKeyDown(teclaAtivar) && objetoAMover != null)
        {
            mover = true;

            // Esconde o texto aqui
            if (textoDica != null)
                textoDica.SetActive(false);

            // Para o movimento do player enquanto o táxi se aproxima
            if (jogadorScript != null)
                jogadorScript.canMove = false;
        }

        // Move o táxi horizontalmente
        if (mover && objetoAMover != null && jogadora != null)
        {
            float alvoX = jogadora.position.x;

            Vector3 novaPos = new Vector3(
                Mathf.MoveTowards(objetoAMover.position.x, alvoX, velocidade * Time.deltaTime),
                objetoAMover.position.y,
                objetoAMover.position.z
            );

            objetoAMover.position = novaPos;

            if (Mathf.Abs(objetoAMover.position.x - alvoX) < 0.2f)
            {
                mover = false;
                if (jogadorScript != null)
                    jogadorScript.canMove = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = true;

            if (textoDica != null)
                textoDica.SetActive(true); // ativa quando entra na área
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = false;
            mover = false;

            if (textoDica != null)
                textoDica.SetActive(false);

            if (jogadorScript != null)
                jogadorScript.canMove = true;
        }
    }
}

