using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerProyectil : MonoBehaviour
{
    public float velocidadMov;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * velocidadMov;
    }

    // Update is called once per frame
    void Update()
    {
        //Se destruye la piedra si se sale de la pantalla
        if (transform.position.x <= -15f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            //Lógica para cuando tocan al enemigo
        }
    }
}
