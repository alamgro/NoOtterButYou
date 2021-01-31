using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerProyectil : MonoBehaviour
{
    public float velocidadMov;

    private Rigidbody2D rb;
    private int vida;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = 1;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * velocidadMov;
    }

    // Update is called once per frame
    void Update()
    {
        ChecarVida();

        //Se destruye la piedra si se sale de la pantalla
        if (transform.position.x <= -20f)
            Destroy(gameObject);
    }

    void ChecarVida()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
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
