using UnityEngine;

public class TaxiTeleport : MonoBehaviour
{
    public Transform pontoDestino;
    public GameObject textoDica;
    public KeyCode teclaAtivar = KeyCode.E;

    private bool playerNaArea = false;

    void Update()
    {
        if (textoDica != null)
            textoDica.SetActive(playerNaArea);

        if (playerNaArea && Input.GetKeyDown(teclaAtivar))
            TeleportarPlayer();
    }

    void TeleportarPlayer()
    {
        if (pontoDestino != null)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            player.position = pontoDestino.position;

            if (textoDica != null)
                textoDica.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNaArea = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = false;
            if (textoDica != null)
                textoDica.SetActive(false);
        }
    }
}
