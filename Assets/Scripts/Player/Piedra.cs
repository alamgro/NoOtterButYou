using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedra : MonoBehaviour
{
    public float velocidadMov;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * velocidadMov;

        //Se destruye la piedra si se sale de la pantalla
        if(transform.position.x > 15f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Amenaza"))
        {
            Destroy(gameObject);
            //Lógica para cuando tocan al enemigo
        }
    }
}
