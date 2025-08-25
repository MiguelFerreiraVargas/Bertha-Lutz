using UnityEngine;

public class HideInside : MonoBehaviour
{
    public KeyCode hideKey = KeyCode.E; // tecla para entrar/sair do esconderijo
    private bool isHidden = false;
    private Transform currentHideSpot;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector3 lastPositionBeforeHide;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (sr == null) Debug.LogError("SpriteRenderer não encontrado no Player!");
        if (rb == null) Debug.LogError("Rigidbody2D não encontrado no Player!");
    }

    void Update()
    {
        if (currentHideSpot != null && Input.GetKeyDown(hideKey))
        {
            isHidden = !isHidden;

            if (isHidden)
            {
                lastPositionBeforeHide = transform.position;

                // Entrar no esconderijo
                sr.enabled = false;
                rb.simulated = false;
                transform.position = currentHideSpot.position;
                Debug.Log("Player se escondeu no: " + currentHideSpot.name);
            }
            else
            {
                // Sair do esconderijo
                sr.enabled = true;
                rb.simulated = true;

                float direction = (lastPositionBeforeHide.x < currentHideSpot.position.x) ? -1f : 1f;
                transform.position = currentHideSpot.position + Vector3.right * direction;
                Debug.Log("Player saiu do esconderijo: " + currentHideSpot.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HideSpot"))
        {
            currentHideSpot = collision.transform;
            Debug.Log("Entrou na trigger do HideSpot: " + collision.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HideSpot"))
        {
            if (!isHidden)
                currentHideSpot = null;
            Debug.Log("Saiu da trigger do HideSpot: " + collision.name);
        }
    }
}
