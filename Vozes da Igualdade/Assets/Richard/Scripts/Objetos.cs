using UnityEngine;
using UnityEngine.UIElements;
public class Objetos : MonoBehaviour
{
    public KeyCode teclaInteracao = KeyCode.E;
    private bool playerInRangeI = false;
    [SerializeField] GameObject poster; 
    // Update is called once per frame
    void Update()
    {
        if (playerInRangeI && Input.GetKeyDown(teclaInteracao))
        {
            poster.SetActive(true);
        }
        else if (Input.GetKeyDown(teclaInteracao))  
        {
            poster.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRangeI = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRangeI = false;
        }
    }
}
