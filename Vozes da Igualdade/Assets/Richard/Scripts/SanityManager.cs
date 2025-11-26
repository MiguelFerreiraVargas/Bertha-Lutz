using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public static SanityManager Instance;

    [Range(0, 100)]
    public float sanidade = 100; // valor inicial

    void Awake()
    {
        // garante que exista só um
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // NÃO destruir ao trocar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AlterarSanidade(float valor)
    {
        sanidade = Mathf.Clamp(sanidade + valor, 0, 100);
        Debug.Log("Sanidade agora: " + sanidade);
    }
}
