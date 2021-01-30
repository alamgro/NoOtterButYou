using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadMov;
    public float frecuenciaDisparo;
    [HideInInspector]
    public bool incapacitado;

    public GameObject piedraPref;
    public GameObject barraOxigenoObj;

    private Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    private float timerDisparo;
    private BarraOxigeno barraOxigenoComp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        barraOxigenoComp = barraOxigenoObj.GetComponent<BarraOxigeno>();
        incapacitado = false;
        timerDisparo = frecuenciaDisparo;
    }

    void Update()
    {
        if (!incapacitado)
        {
            Movimiento();
            Disparo();
            ChecarOxigeno();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    //Si se le acaba el oxígeno, queda incapacitado el Player
    void ChecarOxigeno()
    {
        if (barraOxigenoComp.oxigenoActual <= 0)
        {
            incapacitado = true;
        }
    }

    void Movimiento()
    {
        #region MOVIMIENTO LIBRE PLAYER
        float ejeX = Input.GetAxisRaw("HorizontalWASD");
        float ejeY = Input.GetAxisRaw("VerticalWASD");
        Vector2 vectorMov = new Vector2(ejeX, ejeY).normalized; //Crea un vector con los inputs de movimiento recibidos

        rb.velocity = vectorMov * velocidadMov; //Da la velocidad final al rigidbody
        #endregion
    }

    void Disparo()
    {
        #region DISPARO
        timerDisparo += Time.deltaTime;

        if (Input.GetButtonDown("Piedra1"))
        {
            if (timerDisparo >= frecuenciaDisparo)
            {
                Instantiate(piedraPref, transform.position, Quaternion.identity);
                timerDisparo = 0f; //Reiniciar el contador
            }
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Lógica de cuando tocan al player
        if (collision.CompareTag("Amenaza"))
        {
            //Se le resta de oxígeno al jugador cuando toca una amenaza
            barraOxigenoComp.oxigenoActual -= 10;
        }
        if (collision.CompareTag("Oxigeno"))
        {
            //Se le resta de oxígeno al jugador cuando toca una amenaza
            barraOxigenoComp.oxigenoActual += 10;
        }
    }

}
