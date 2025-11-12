using UnityEngine;

public class PuzzleLuzes : MonoBehaviour
{
    [Header("Configurações")]
    public Light luzPrincipal;         // Luz que acende quando o puzzle é resolvido
    public BarraDeVida barraDeVida;    // Referência à sanidade
    public KeyCode teclaInteragir = KeyCode.E;
    public GameObject[] botoes;        // Os 3 interruptores (objetos com colliders)

    private int[] ordemCorreta = { 1, 2, 3 }; // Ordem que deve ser apertada
    private int progresso = 0;               // Qual botão o jogador está tentando
    private bool resolvido = false;

    void Start()
    {
    //    luzPrincipal.enabled = false; // começa apagada
    }

    public void PressionarBotao(int numero)
    {
        if (resolvido) return;

        if (ordemCorreta[progresso] == numero)
        {
            progresso++;
            Debug.Log("Acertou parte " + progresso);

            if (progresso >= ordemCorreta.Length)
            {
                Resolvido();
            }
        }
        else
        {
            Debug.Log("Errou! Sanidade -5");
            barraDeVida.sanity -= 5;
            barraDeVida.sanity = Mathf.Clamp(barraDeVida.sanity, 0, barraDeVida.sanityMax);
            progresso = 0; // reseta sequência
        }
    }

    void Resolvido()
    {
        resolvido = true;
        luzPrincipal.enabled = true;
        Debug.Log("Puzzle resolvido! A luz acendeu.");
    }
}