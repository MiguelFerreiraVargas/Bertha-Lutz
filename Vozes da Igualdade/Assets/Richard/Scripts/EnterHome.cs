using UnityEngine;

public class EnterHome : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    bool isColliding = false;
    KeyHome keyH; 
    void Update()
    {
     if (isColliding && Input.GetKeyDown(teclaInteracao)  && keyH.keyHome)
        {

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
        }
    }
}
