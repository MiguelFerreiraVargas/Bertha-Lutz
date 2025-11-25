using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScene : MonoBehaviour
{
    public string sceneName;

    // Esta função é chamada quando o botão recebe ENTER/ESPAÇO
    public void Press()
    {
        SceneManager.LoadScene(sceneName);
    }
}
