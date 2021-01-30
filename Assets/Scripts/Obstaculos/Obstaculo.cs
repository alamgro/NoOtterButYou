using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
	public int vida;
	public float velocidad;

	private Rigidbody2D rb; //Rigidbody2D del obstáculo

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//Si no hay un evento activo el objeto sigue en movimiento, sino, su velocidad es 0 en X y Y
		rb.velocity = Vector2.left * velocidad; //Le da la velocidad de movimiento al obstáculo
	}

    private void Update()
    {
		ChecarVida();

		if (transform.position.x <= -15f)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
		//Si le pega una piedra, pierde uno de vida
        if (collision.CompareTag("Piedra"))
        {
			vida--;
        }
    }

}
