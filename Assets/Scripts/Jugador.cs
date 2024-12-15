using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] int velocidad;
    [SerializeField] int idJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(0, 1, 0) * velocidad * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(new Vector3(0, -1, 0) * velocidad * Time.deltaTime);
        //}

        float v = Input.GetAxisRaw("Vertical" + idJugador);
        transform.Translate(new Vector3(0, v, 0) * velocidad * Time.deltaTime); //Para que se mueva en la Y.

        // Vamos a Limitar la posicion: Clampear.
        float yClamped = Mathf.Clamp(transform.position.y, -3, 3);

        //Mi posicion no se va a pasar de los margenes.
        transform.position = new Vector3(transform.position.x, yClamped, transform.position.z);
    }
}
