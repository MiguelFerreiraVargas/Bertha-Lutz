using UnityEngine;

public class MirrorPuzzle : MonoBehaviour
{
    public GameObject puzzleTela;      // sprite do puzzle
    public GameObject documento;       // documento para liberar
    public GameObject hitboxInvertida; // collider sobre a parte invertida

    public float timer = 90f;
    bool puzzleAtivo = false;
    bool timerRodando = true; // começa ao entrar na sala

    void Start()
    {
        puzzleTela.SetActive(false);
        documento.SetActive(false);
    }

    void Update()
    {
        // TIMER
        if (timerRodando && !puzzleAtivo)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Acabou o tempo → começa a perder sanidade
                FindAnyObjectByType<BarraDeVida>().sanity -= 20 * Time.deltaTime;
            }
        }

        // CLIQUE NO PUZZLE
        if (puzzleAtivo && Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (col != null && col.gameObject == hitboxInvertida)
            {
                ResolverPuzzle();
            }
        }
    }

    public void AbrirPuzzle()
    {
        puzzleTela.SetActive(true);
        puzzleAtivo = true;
        timerRodando = false;
    }

    void ResolverPuzzle()
    {
        puzzleTela.SetActive(false);
        documento.SetActive(true);
        puzzleAtivo = false;
        timerRodando = false;
    }
}