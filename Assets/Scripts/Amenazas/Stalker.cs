using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public float velocidadMov;
    public int vida;
    public GameObject proyectilPref;

    private Rigidbody2D rb; //Rigidbody2D del obstáculo
    private GameObject[] players;
    private int randPlayer; //Con esto decidirá a cuál player seguir desde el inicio

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        players = GameObject.FindGameObjectsWithTag("Player"); //Encontrar a todos los player
        randPlayer = Random.Range(0, players.Length); //Elegir el player a seguir
        InvokeRepeating("DispararProyectil", 4f, 1f);
    }

    void FixedUpdate()
    {
        /*rb.velocity = Vector2.left * velocidadActual; //Le da la velocidad de movimiento al obstáculo
        transform.position = new Vector2(transform.position.x, players[randPlayer].transform.position.y);*/

        if(transform.position.x >= -5.5f)
        {
            //Hacer que siga al player
            transform.position = Vector2.MoveTowards(transform.position, players[randPlayer].transform.position, 0.45f); 
            //Atrasar un poco el movimiento en X, pero que lo siga más rápido en Y
            transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y);
        }
        else
        {
            rb.velocity = Vector2.left * velocidadMov; //Le da la velocidad de movimiento al obstáculo
        }
    }

    // Update is called once per frame
    void Update()
    {
		ChecarVida();

        if (transform.position.x <= -20f)
        {
            Destroy(gameObject);
        }
    }


    //Verificar si su vida llegó a 0 o menos, en ese caso se destruye este obstáculo
    void ChecarVida()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    void DispararProyectil()
    {
        Instantiate(proyectilPref, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si le pega una piedra, pierde uno de vida
        if (collision.CompareTag("Piedra"))
        {
            vida--;
        }
    }
}
