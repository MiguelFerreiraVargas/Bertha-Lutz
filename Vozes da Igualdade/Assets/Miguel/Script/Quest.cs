using UnityEngine;

public class NPCMissao : MonoBehaviour
{
    [Header("Documento que o NPC vai entregar")]
    public GameObject documentoParaDar;

    private bool missaoAtivada = false;
    private bool jogadorTemItem = false;

    private void Start()
    {
        if (documentoParaDar != null)
            documentoParaDar.SetActive(false);
    }

    public void Interagir()
    {
        // Primeira fala
        if (!missaoAtivada)
        {
            PainelDeDialogo.instance.MostrarTexto(
                "Tente achar meu amuleto no labirinto e desvie dos inimigos…\n" +
                "Se você o encontrar, traga pra mim e eu te darei oque voce precisa.!"
            );

            missaoAtivada = true;
            return;
        }

        // Jogador voltou sem o item
        if (missaoAtivada && !jogadorTemItem)
        {
            PainelDeDialogo.instance.MostrarTexto(
                "Você ainda não encontrou meu amuleto.\n" +
                "Continue procurando."
            );
            return;
        }

        // Jogador voltou com o item
        if (missaoAtivada && jogadorTemItem)
        {
            PainelDeDialogo.instance.MostrarTexto(
                "Você realmente conseguiu encontrar!\n" +
                "Aqui está o documento que prometi."
            );

            if (documentoParaDar != null)
                documentoParaDar.SetActive(true);
        }
    }

    public void JogadorPegouItem()
    {
        jogadorTemItem = true;
    }
}
