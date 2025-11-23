using UnityEngine;

public class VisaoCone : MonoBehaviour
{
    public InimigoLabirinto inimigo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inimigo.playerDetectado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inimigo.playerDetectado = false;
        }
    }
}
