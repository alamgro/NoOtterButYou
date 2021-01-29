using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float oxigenoVida;
    public float velocidadMov;

    private Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #region MOVIMIENTO LIBRE PLAYER
        float ejeX = Input.GetAxisRaw("HorizontalWASD");
        float ejeY = Input.GetAxisRaw("VerticalWASD");
        Vector2 vectorMov = new Vector2(ejeX, ejeY).normalized; //Crea un vector con los inputs de movimiento recibidos

        rb.velocity = vectorMov * velocidadMov; //Da la velocidad final al rigidbody
        #endregion

        #region DISPARO
        if (Input.GetButtonDown("Piedra1"))
        {
            Debug.Log("Piedra Lanzada!", gameObject);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Lógica de cuando tocan al player
        if (collision.CompareTag("Amenaza"))
        {
            //Se le resta de oxígeno al jugador cuando toca una amenaza
            oxigenoVida -= 10f;
        }
    }

}
