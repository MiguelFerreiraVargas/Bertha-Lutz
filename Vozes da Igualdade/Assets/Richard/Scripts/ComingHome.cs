using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComingHome : MonoBehaviour
{
    [Header("Teleporte")]
    public Transform pontoDestino;
    public GameObject textoDica;
    public KeyCode teclaAtivar = KeyCode.E;

    [Header("Fade")]
    [SerializeField] private Image fadeImage; // imagem preta na tela
    [SerializeField] private float fadeSpeed = 1.5f; // velocidade do fade
    [SerializeField] private float delayAntesTeleportar = 0.3f;

    private bool playerNaArea = false;
    private bool isTeleportando = false;

    void Update()
    {
        if (textoDica != null)
            textoDica.SetActive(playerNaArea && !isTeleportando);

        if (playerNaArea && Input.GetKeyDown(teclaAtivar) && !isTeleportando)
            StartCoroutine(FazerTeleporte());
    }

    private IEnumerator FazerTeleporte()
    {
        isTeleportando = true;

        // Fade para preto
        yield return StartCoroutine(FadeTo(1f));

        // Espera um tempinho antes de teleportar
        yield return new WaitForSeconds(delayAntesTeleportar);

        // Teleporta o jogador
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (pontoDestino != null)
            player.position = pontoDestino.position;

        // Fade de volta para claro
        yield return StartCoroutine(FadeTo(0f));

        isTeleportando = false;
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        Color color = fadeImage.color;

        while (!Mathf.Approximately(color.a, targetAlpha))
        {
            color.a = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeImage.color = color;
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNaArea = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = false;
            if (textoDica != null)
                textoDica.SetActive(false);
        }
    }
}
