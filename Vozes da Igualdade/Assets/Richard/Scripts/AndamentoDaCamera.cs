using UnityEngine;

public class AndamentoDaCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.200f;

    void Start()
    {
        // Tenta achar o player no início
        EncontrarPlayer();
    }

    void Update()
    {
        // Se o target sumiu (troca de cena), tenta achar de novo
        if (target == null)
            EncontrarPlayer();

        if (target == null) return; // ainda não achou → evita erro

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

    void EncontrarPlayer()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            target = p.transform;
    }
}
