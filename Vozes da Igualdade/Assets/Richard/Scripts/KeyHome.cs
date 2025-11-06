using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyHome : MonoBehaviour
{
    public string loadScene = "SampleScene"; 

   public bool keyHome = false;
   public bool hasLoaded = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            keyHome = true;
        }
    }
}
