using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour
{
    public int index;              // botão selecionado
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex; // último índice
    public GameObject[] buttons;   // coloque seus botões aqui
    public AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // --- NAVEGAÇÃO VERTICAL ---
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0) // pra baixo
                {
                    if (index < maxIndex)
                        index++;
                    else
                        index = 0;
                }
                else if (Input.GetAxis("Vertical") > 0) // pra cima
                {
                    if (index > 0)
                        index--;
                    else
                        index = maxIndex;
                }

                // Seleciona o novo botão no EventSystem
                EventSystem.current.SetSelectedGameObject(buttons[index]);

                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }


        // --- CONFIRMAR COM O MOUSE ---
        if (Input.GetMouseButtonDown(0)) // botão esquerdo do mouse
        {
            GameObject botaoAtual = buttons[index];

            var loader = botaoAtual.GetComponent<MenuButtonScene>();

            if (loader != null)
            {
                loader.Press();  // carrega a cena correta
            }
        }
    }
}

