using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ContextualizacaoDaHistoria : MonoBehaviour
{
    [SerializeField] GameObject primeiraPagina;
    [SerializeField] GameObject botaoAveriguar;
    [SerializeField] GameObject objetoTeste;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botaoAveriguar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Mostre(); 
        }
  
    }
    void Mostre ()
    {
        botaoAveriguar.SetActive(true);
    }
    public void MostrarCarta ()
    {
        primeiraPagina.SetActive(true);
        botaoAveriguar.SetActive(false);
    }
    public void fecharCarta ()
    {
        primeiraPagina.SetActive(false);
    
    }
}
