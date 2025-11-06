using System.Xml;
using UnityEngine;
public class KeyHome : MonoBehaviour
{
   public bool keyHome = false;
   public bool hasLoaded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            keyHome = true;
            Debug.Log("KeyCollected"); 
        }
    }
}
