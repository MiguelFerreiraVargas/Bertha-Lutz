using UnityEngine;

public class PuzzleSequencia : MonoBehaviour
{
    [Header("Configuração dos Botões")]
    public BotaoSequencia[] botoes; // arraste os botões na ordem da sequência correta
    private int indiceAtual = 0;

    [Header("Recompensa")]
    public string itemName = "Anotação Misteriosa";
    public int itemId = 101;
    public string description = "Um papel rabiscado com símbolos estranhos.";
    public Sprite icon;
    public int value = 1;

    private bool resolvido = false;
    private BarraDeVida barra;
    private Inventoryy inventario;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            barra = player.GetComponent<BarraDeVida>();
            inventario = player.GetComponent<Inventoryy>();
        }

        // Conecta os botões a este puzzle
        foreach (BotaoSequencia b in botoes)
            b.puzzlePai = this;
    }

    public void BotaoPressionado(BotaoSequencia botao)
    {
        if (resolvido) return;

        if (botoes[indiceAtual] == botao)
        {
            indiceAtual++;
            botao.CorretamentePressionado();

            if (indiceAtual >= botoes.Length)
                ResolverPuzzle();
        }
        else
        {
            // errou
            if (barra != null)
            {
                barra.sanity -= 5f;
                barra.sanity = Mathf.Clamp(barra.sanity, 0, barra.sanityMax);
            }
            indiceAtual = 0; // reinicia sequência
            foreach (BotaoSequencia b in botoes)
                b.ResetarCor();
        }
    }

    void ResolverPuzzle()
    {
        resolvido = true;
        Debug.Log(" Puzzle resolvido! Item adicionado.");

        if (inventario != null)
            inventario.AddItem(itemName, itemId, description, icon, value);
    }
}