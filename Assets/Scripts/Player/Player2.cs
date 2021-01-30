using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    #region VARIABLES PÚBLICAS
    public float velocidadMov;
    public float frecuenciaDisparo;

    public GameObject piedraPref;
    public GameObject barraOxigenoObj;
    public Transform otroPlayer;
    #endregion

    #region VARIABLES PRIVADAS
    private Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    private BarraOxigeno barraOxigenoComp;
    private SpriteRenderer spritePlayer;

    private float timerDisparo;
    private float timerRecuperacion;
    private bool incapacitado;
    private bool inmunidad;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        barraOxigenoComp = barraOxigenoObj.GetComponent<BarraOxigeno>();
        spritePlayer = GetComponent<SpriteRenderer>();
        incapacitado = inmunidad = false; //Por defecto estos estados inician desactivados
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
            rb.velocity = Vector2.zero; //Hace que se detenga al instante cuando está incapacitado
            float distanciaPlayers = Vector3.Distance(transform.position, otroPlayer.position); //Calcula la distancia entre el los jugadores

            //Revisa que la distancia entre los players sea la suficiente para recuperarlo de la incapacidad
            if (distanciaPlayers <= 1.1f)
            {
                timerRecuperacion += Time.deltaTime;
                barraOxigenoComp.oxigenoActual = ((barraOxigenoComp.oxigenoMax / 2.0f) * timerRecuperacion); //Rellenarle el oxígeno al 100%

                //Cuando está en rango de revivir por dos segundos, lo revive
                if (timerRecuperacion >= 2f)
                {
                    print("Recuperado");
                    incapacitado = false; //Quitamos la incapacidad
                    barraOxigenoComp.oxigenoActual = barraOxigenoComp.oxigenoMax; //Rellenarle el oxígeno al 100%
                }
            }
            else
            {
                timerRecuperacion = 0f;
            }
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
        float ejeX = Input.GetAxisRaw("HorizontalFLECHAS");
        float ejeY = Input.GetAxisRaw("VerticalFLECHAS");
        Vector2 vectorMov = new Vector2(ejeX, ejeY).normalized; //Crea un vector con los inputs de movimiento recibidos

        rb.velocity = vectorMov * velocidadMov; //Da la velocidad final al rigidbody
        #endregion
    }

    void Disparo()
    {
        #region DISPARO
        timerDisparo += Time.deltaTime;

        if (Input.GetButtonDown("Piedra2"))
        {
            if (timerDisparo >= frecuenciaDisparo)
            {
                Instantiate(piedraPref, transform.position, Quaternion.identity);
                timerDisparo = 0f; //Reiniciar el contador
            }
        }
        #endregion
    }

    IEnumerator InvocarParpadeo(float _tiempo)
    {
        InvokeRepeating("ParpadeoInmune", 0f, 0.05f);
        yield return new WaitForSeconds(_tiempo);
        spritePlayer.enabled = true; //Forzar a que termine siendo visible en el último frame
        CancelInvoke("ParpadeoInmune");
        inmunidad = false; //Le quita la inmunidad después de un tiempo
    }

    void ParpadeoInmune()
    {
        print(spritePlayer.enabled);
        spritePlayer.enabled = !spritePlayer.enabled;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Solo puede obtener o perder oxígeno si no está incapacitado
        if (!incapacitado)
        {
            //Lógica de cuando tocan al player
            if (collision.CompareTag("Amenaza"))
            {
                if (!inmunidad)
                {
                    //Se le resta de oxígeno al jugador cuando toca una amenaza
                    barraOxigenoComp.oxigenoActual -= 10;
                    inmunidad = true; //Dar inmunidad
                    StartCoroutine(InvocarParpadeo(1f));
                }
            }

            if (collision.CompareTag("Oxigeno"))
            {
                //Se le resta de oxígeno al jugador cuando toca una amenaza
                barraOxigenoComp.oxigenoActual += 10;
            }
        }
    }
}
