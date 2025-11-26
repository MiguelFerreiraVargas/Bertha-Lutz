using UnityEngine;

public class Animation1 : MonoBehaviour
{
    public Animator anim;

    private string currentState = "";

    void Start()
    {
        if (anim == null)
            anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // sem movimento → Idle
        if (x == 0 && y == 0)
        {
            ChangeState("REALIDLE]");
            return;
        }

        // ordem de prioridade:
        // vertical primeiro (W / S)
        if (Mathf.Abs(y) > Mathf.Abs(x))
        {
            if (y > 0)
                ChangeState("wALkUp");
            else
                ChangeState("WalkRight");
        }
        else
        {
            if (x > 0)
                ChangeState("WalkRightcerto");
            else
                ChangeState("WalkLeft");
        }
    }

    void ChangeState(string newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
        anim.Play(newState, 0, 0f);
    } 
}
