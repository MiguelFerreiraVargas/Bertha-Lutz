using UnityEngine;
using UnityEngine.InputSystem; // Novo sistema

public class TesteAndando : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        movement = Vector2.zero;

        if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            movement.x = -1;
        if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            movement.x = 1;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}