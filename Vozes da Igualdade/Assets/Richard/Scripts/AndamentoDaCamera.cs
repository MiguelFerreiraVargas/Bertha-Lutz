using UnityEngine;

public class AndamentoDaCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;       // O player ou trailer
    public Vector3 offset;         // Distância da câmera em relação ao alvo
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Opcional: se quiser que a câmera "olhe" para o alvo
    }
}
