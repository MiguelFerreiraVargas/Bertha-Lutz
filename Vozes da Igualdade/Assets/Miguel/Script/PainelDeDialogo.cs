using UnityEngine;
using TMPro;

public class PainelDeDialogo : MonoBehaviour
{
    public static PainelDeDialogo instance;

    [Header("Referências UI")]
    public GameObject painel;
    public TMP_Text textoUI;

    private bool painelAberto = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (painel != null)
            painel.SetActive(false);
    }

    private void Update()
    {
        // SE O PAINEL ESTIVER ABERTO E O PLAYER APERTAR E → fecha
        if (painelAberto && Input.GetKeyDown(KeyCode.E))
        {
            Fechar();
        }
    }

    public void MostrarTexto(string mensagem)
    {
        if (painel == null || textoUI == null)
        {
            Debug.LogWarning("PainelDeDialogo: painel/texto não atribuídos!");
            return;
        }

        textoUI.text = mensagem;
        painel.SetActive(true);
        painelAberto = true;
    }

    public void Fechar()
    {
        if (painel != null)
            painel.SetActive(false);

        painelAberto = false;
    }
}
