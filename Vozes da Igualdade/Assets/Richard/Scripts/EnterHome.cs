using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHome : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.F;
    private bool isColliding = false;
    private KeyHome keyH;

    public string loadScene = "SampleScene";

    [Header("UI")]
    public GameObject pressE;
    public GameObject pressF;

    void Start()
    {
        keyH = FindAnyObjectByType<KeyHome>();

        // Garante que os botões comecem invisíveis
        if (pressE != null) pressE.SetActive(false);
        if (pressF != null) pressF.SetActive(false);
    }

    void Update()
    {
        if (!isColliding) return;

        // Atualiza os ícones de acordo com o estado da chave
        UpdateUI();

        if (Input.GetKeyDown(teclaInteracao) && keyH != null && keyH.keyHome)
        {
            SceneManager.LoadScene(loadScene);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            UpdateUI();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;

            // Esconde os ícones
            if (pressE != null) pressE.SetActive(false);
            if (pressF != null) pressF.SetActive(false);
        }
    }

    void UpdateUI()
    {
        if (pressE == null || pressF == null) return;

        if (keyH != null && keyH.keyHome)
        {
            // Já tem a chave → mostra F, esconde E
            pressE.SetActive(false);
            pressF.SetActive(true);
        }
        else
        {
            // Não tem a chave → mostra E, esconde F
            pressE.SetActive(true);
            pressF.SetActive(false);
        }
    }
}
