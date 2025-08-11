using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private float direcao;
    private Rigidbody rb;
    private float jumpForce = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");
    }
}
