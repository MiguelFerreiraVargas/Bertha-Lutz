using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Animator playerAnimator;

    private bool wasWalking = false;

    void Start()
    {
        if (playerAnimator == null)
            playerAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // detecta movimento
        bool isWalking = Input.GetKey(KeyCode.W) ||
                         Input.GetKey(KeyCode.A) ||
                         Input.GetKey(KeyCode.S) ||
                         Input.GetKey(KeyCode.D);

        // mostra no console pra testar
        Debug.Log("isWalking: " + isWalking);

        // só troca quando o estado muda (evita reiniciar animação todo frame)
        if (isWalking && !wasWalking)
        {
            Debug.Log(">> Tocando WALKING");
            playerAnimator.Play("Walking2", 0, 0f);
        }
        else if (!isWalking && wasWalking)
        {
            Debug.Log(">> Tocando IDLE");
            playerAnimator.Play("Idle2", 0, 0f);
        }

        wasWalking = isWalking;
    }
}
