using UnityEngine;

public class ContextualizacaoDaHistoria : MonoBehaviour
{
    [SerializeField] GameObject primeiraPagina; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       primeiraPagina.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarCarta ()
    {
        primeiraPagina.SetActive(true);
    }
    public void fecharCarta ()
    {
        primeiraPagina.SetActive(false);
    }
}
