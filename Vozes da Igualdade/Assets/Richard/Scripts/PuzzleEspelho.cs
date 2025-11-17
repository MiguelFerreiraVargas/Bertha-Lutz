using UnityEngine;
using UnityEngine.UI;

public class PuzzleEspelhoSimples : MonoBehaviour
{
    [Header("UI do Puzzle")]
    public GameObject puzzleUI;          // painel do puzzle
    public GameObject pressE;            // texto "aperte E"

    [Header("Sistema")]
    public GameObject documento;         // documento que libera ao resolver
    public Timer timer;                  // seu script do timer

    [Header("Puzzle")]
    public Image[] botoes;               // 3 botões do puzzle (UI Image)
    public Sprite[] opcoes;              // sprites possíveis
    public Sprite[] ordemCorreta;        // ordem correta final

    private bool podeInteragir;
    private int[] index;                 // qual sprite está em cada botão

    void Start()
    {
        index = new int[botoes.Length];

        // inicia puzzle desligado
        puzzleUI.SetActive(false);
        pressE.SetActive(false);
    }

    void Update()
    {
        // interagir
        if (podeInteragir && Input.GetKeyDown(KeyCode.E))
        {
            puzzleUI.SetActive(true);
            pressE.SetActive(false);
        }
    }

    // chamado pelos botões (via OnClick no inspector)
    public void ClicarBotao(int id)
    {
        index[id]++;

        if (index[id] >= opcoes.Length)
            index[id] = 0;

        botoes[id].sprite = opcoes[index[id]];

        VerificarPuzzle();
    }

    void VerificarPuzzle()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            if (botoes[i].sprite != ordemCorreta[i])
                return;
        }

        // resolveu 🎉
        puzzleUI.SetActive(false);
        documento.SetActive(true);
        timer.StopTimer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = true;
            pressE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            podeInteragir = false;
            pressE.SetActive(false);
        }
    }
}