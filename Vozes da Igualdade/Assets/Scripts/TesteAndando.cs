using UnityEngine;
using UnityEngine.InputSystem; // Novo sistema

public class TesteAndando : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, y, 0);

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}