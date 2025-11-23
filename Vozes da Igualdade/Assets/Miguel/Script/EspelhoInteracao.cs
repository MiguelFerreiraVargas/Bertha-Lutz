using UnityEngine;

public class EspelhoInteracao : MonoBehaviour
{
    [Header("Referências")]
    public MirrorPuzzle puzzle;          // script do puzzle
    public GameObject painelInteracao;   // UI "Aperte E"

    [Header("Configurações")]
    public KeyCode tecla = KeyCode.E;

    private bool perto = false;

    void Start()
    {
        if (painelInteracao != null)
            painelInteracao.SetActive(false); // começa desligado
    }

    void Update()
    {
        // Mostrar painel só quando perto e puzzle ainda não aberto
        if (painelInteracao != null)
            painelInteracao.SetActive(perto && !puzzle.ativo);

        if (perto && Input.GetKeyDown(tecla))
        {
            puzzle.AtivarPuzzle();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            perto = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            perto = false;
    }
}
