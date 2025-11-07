
using UnityEngine;

public class SpundMenu : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip som;

    void Start()

    {

        if (som != null && audioSource != null)

        {

            audioSource.clip = som;

            audioSource.Play();

            Debug.Log("Som de menu executado!");

        }

        else

        {

            Debug.LogWarning("AudioSource ou AudioClip est� nulo.");

        }

    }

}

