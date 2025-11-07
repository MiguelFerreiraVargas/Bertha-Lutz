using UnityEngine;
using UnityEngine.UI;

public class BotaoSequencia : MonoBehaviour
{
    public PuzzleSequencia puzzlePai;
    private Button botao;
    private Image imagem;
    private Color corOriginal;

    void Start()
    {
        botao = GetComponent<Button>();
        imagem = GetComponent<Image>();
        corOriginal = imagem.color;
        botao.onClick.AddListener(() => puzzlePai.BotaoPressionado(this));
    }

    public void CorretamentePressionado()
    {
        imagem.color = Color.green;
    }

    public void ResetarCor()
    {
        imagem.color = corOriginal;
    }
}
