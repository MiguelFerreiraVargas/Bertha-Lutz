using UnityEngine;
using UnityEngine.UI;

public class MirrorPuzzle : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelPuzzle;

    [Header("Portas (configure no Inspector)")]
    // Porta que representa a porta fechada (visível antes do puzzle ser completado)
    public GameObject portaFechada;
    // Porta que deve aparecer / ficar visível depois de completar o puzzle
    public GameObject portaAberta;
    // Referência opcional ao script da porta (mantida caso precise no futuro)
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

    void Start()
    {
        // proteção contra referências nulas
        if (painelPuzzle != null) painelPuzzle.SetActive(false);

        // Garantir estado inicial das portas (ajuste conforme sua cena)
        if (portaFechada != null) portaFechada.SetActive(true);
        if (portaAberta != null) portaAberta.SetActive(false);

        // se a doorConfig não foi atribuída manualmente, tenta pegar do portaAberta (não será usada automaticamente aqui)
        if (doorConfig == null && portaAberta != null)
            doorConfig = portaAberta.GetComponent<DoorConfig>();

        // Só adiciona listeners se os botões existirem
        if (botaoA != null) botaoA.onClick.AddListener(() => Clicar("A"));
        if (botaoB != null) botaoB.onClick.AddListener(() => Clicar("B"));
        if (botaoC != null) botaoC.onClick.AddListener(() => Clicar("C"));
    }

    void OnDestroy()
    {
        // remover listeners para evitar leaks/exceptions em edição
        if (botaoA != null) botaoA.onClick.RemoveAllListeners();
        if (botaoB != null) botaoB.onClick.RemoveAllListeners();
        if (botaoC != null) botaoC.onClick.RemoveAllListeners();
    }

    // Não permite abrir o puzzle se já foi completado
    public void AtivarPuzzle()
    {
        if (completado) return;
        if (painelPuzzle != null) painelPuzzle.SetActive(true);
        ativo = true;

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

        if (entradaPlayer.Length == ordemCorreta.Length)
        {
            if (entradaPlayer == ordemCorreta)
                PuzzleCompleto();
            else
                entradaPlayer = "";
        }
    }

    void PuzzleCompleto()
    {
        completado = true;

        // Mostrar a porta "aberta" e esconder a fechada
        if (portaFechada != null) portaFechada.SetActive(false);
        if (portaAberta != null) portaAberta.SetActive(true);

        // NÃO chamamos doorConfig.Unlock() aqui mais — remoção solicitada.
        // Se não existir DoorConfig, garantimos que o collider da porta aberta esteja habilitado
        if (portaAberta != null)
        {
            Collider2D c2 = portaAberta.GetComponent<Collider2D>();
            if (c2 != null) c2.enabled = true;
            Collider c3 = portaAberta.GetComponent<Collider>();
            if (c3 != null) c3.enabled = true;
        }

        if (timer != null) timer.PararTimer();
        FecharPuzzle();
    }
}