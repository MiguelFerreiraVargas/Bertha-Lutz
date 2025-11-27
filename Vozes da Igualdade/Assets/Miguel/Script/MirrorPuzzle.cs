using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MirrorPuzzle : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelPuzzle;

    [Header("Portas (configure no Inspector)")]
    public GameObject portaFechada;
    public GameObject portaAberta;
    public DoorConfig doorConfig;

    [Header("Botões do Puzzle")]
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;

    [Header("Sistema")]
    public string ordemCorreta = "ABC";
    private string entradaPlayer = "";

    public bool ativo = false;
    private bool completado = false;

    [Header("Timer")]
    public TimerBanheiro timer;

    [Header("Contador de Letras")]
    public TMP_Text contadorTexto;   // <- ARRASTE O TEXTO AQUI
    private int contador = 0;

    void Start()
    {
        if (painelPuzzle != null) painelPuzzle.SetActive(false);

        if (portaFechada != null) portaFechada.SetActive(true);
        if (portaAberta != null) portaAberta.SetActive(false);

        if (doorConfig == null && portaAberta != null)
            doorConfig = portaAberta.GetComponent<DoorConfig>();

        if (botaoA != null) botaoA.onClick.AddListener(() => Clicar("A"));
        if (botaoB != null) botaoB.onClick.AddListener(() => Clicar("B"));
        if (botaoC != null) botaoC.onClick.AddListener(() => Clicar("C"));

        AtualizarContador();
    }

    void OnDestroy()
    {
        if (botaoA != null) botaoA.onClick.RemoveAllListeners();
        if (botaoB != null) botaoB.onClick.RemoveAllListeners();
        if (botaoC != null) botaoC.onClick.RemoveAllListeners();
    }

    public void AtivarPuzzle()
    {
        if (completado) return;

        if (painelPuzzle != null) painelPuzzle.SetActive(true);
        ativo = true;

        contador = 0;
        entradaPlayer = "";
        AtualizarContador();

        if (timer != null) timer.IniciarTimer();
    }

    public void FecharPuzzle()
    {
        if (painelPuzzle != null) painelPuzzle.SetActive(false);
        ativo = false;

        if (timer != null) timer.PararTimer();
    }

    void Clicar(string letra)
    {
        if (!ativo) return;

        entradaPlayer += letra;
        contador++;
        AtualizarContador();

        if (entradaPlayer.Length == ordemCorreta.Length)
        {
            if (entradaPlayer == ordemCorreta)
            {
                PuzzleCompleto();
            }
            else
            {
                // ERROU → ZERA
                entradaPlayer = "";
                contador = 0;
                AtualizarContador();
            }
        }
    }

    void AtualizarContador()
    {
        if (contadorTexto != null)
        {
            contadorTexto.text = $"Letras: {contador}/3";
        }
    }

    void PuzzleCompleto()
    {
        completado = true;

        if (portaFechada != null) portaFechada.SetActive(false);
        if (portaAberta != null) portaAberta.SetActive(true);

        Collider2D c2 = portaAberta.GetComponent<Collider2D>();
        if (c2 != null) c2.enabled = true;

        Collider c3 = portaAberta.GetComponent<Collider>();
        if (c3 != null) c3.enabled = true;

        if (timer != null) timer.PararTimer();

        FecharPuzzle();
    }
}
