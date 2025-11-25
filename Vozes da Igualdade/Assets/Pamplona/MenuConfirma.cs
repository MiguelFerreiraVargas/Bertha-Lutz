using UnityEngine;
using UnityEngine.EventSystems;

public class MenuConfirma : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // pega o botão atualmente selecionado pelo EventSystem
            GameObject selecionado = EventSystem.current.currentSelectedGameObject;

            if (selecionado != null)
            {
                // tenta pegar o script MenuButtonScene do botão
                MenuButtonScene sceneLoader = selecionado.GetComponent<MenuButtonScene>();

                if (sceneLoader != null)
                {
                    // chama a função Press() que você queria
                    sceneLoader.Press();
                }
            }
        }
    }
}
