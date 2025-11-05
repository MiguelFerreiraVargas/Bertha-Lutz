using UnityEngine;

public class TaxiTeleport : MonoBehaviour
{
    [Header("Configura��es")]
    public KeyCode teclaAtivar = KeyCode.F;   // Tecla que ativa o t�xi
    public Transform jogadora;                // Refer�ncia ao player
    public Transform objetoAMover;            // O "t�xi" que vai se mover
    public float velocidade = 5f;             // Velocidade do t�xi
    public GameObject textoDica;              // Texto de dica na tela

    private bool playerNaArea = false;        // Indica se o player est� na trigger
    private bool mover = false;               // Controla o movimento do t�xi
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
        // Ativa o movimento do t�xi quando o player aperta a tecla
        if (playerNaArea && Input.GetKeyDown(teclaAtivar) && objetoAMover != null)
        {
            mover = true;

            // Esconde o texto aqui
            if (textoDica != null)
                textoDica.SetActive(false);

            // Para o movimento do player enquanto o t�xi se aproxima
            if (jogadorScript != null)
                jogadorScript.canMove = false;
        }

        // Move o t�xi horizontalmente
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
                textoDica.SetActive(true); // ativa quando entra na �rea
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
