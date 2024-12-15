using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 posicionInicial;
    [SerializeField] float velocidad;
    [SerializeField] int scorePlayer1;
    [SerializeField] int scorePlayer2;
    [SerializeField] private TMP_Text textoScore1;
    [SerializeField] private TMP_Text textoScore2;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(1, 1, 0).normalized * velocidad, ForceMode2D.Impulse);
        posicionInicial = this.gameObject.transform.position; // Guardo la posicion inicial.
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Porteria1"))
        {
            scorePlayer2++;
            textoScore2.SetText("Score: " + scorePlayer2);

            transform.position = posicionInicial; // Vuelvo a la posicion inicial.
            ReiniciarBola();
        }
        else if (other.gameObject.CompareTag("Porteria2"))
        {
            scorePlayer1++;
            textoScore1.SetText("Score: " + scorePlayer1);

            transform.position = posicionInicial; // Vuelvo a la posicion inicial.
            ReiniciarBola();
        }
    }
    void ReiniciarBola()
    {
        rb.velocity = new Vector3(0, 0, 0); //Paro la bola en seco.

        int xAleatoria = Random.Range(-1, 2);
        int yAleatoria = Random.Range(-1, 2);

        //MIENTRAS xAleatoria 0 o yAleatoria sean igual a 0
        while (xAleatoria == 0 || yAleatoria == 0)
        {
            xAleatoria = Random.Range(-1, 2);
            yAleatoria = Random.Range(-1, 2);
        }

        rb.AddForce(new Vector3(xAleatoria, yAleatoria, 0).normalized * velocidad, ForceMode2D.Impulse);

    }

}
