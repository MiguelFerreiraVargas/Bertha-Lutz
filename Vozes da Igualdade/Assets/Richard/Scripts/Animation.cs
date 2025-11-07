using UnityEngine;

public class Animation : MonoBehaviour
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
            playerAnimator.Play("Walkinfforreal", 0, 0f);
        }
        else if (!isWalking && wasWalking)
        {
            Debug.Log(">> Tocando IDLE");
            playerAnimator.Play("Idle", 0, 0f);
        }

        wasWalking = isWalking;
    }
}
