using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 */
public class PezEspada : MonoBehaviour
{
	public float velocidadMov;
	public float velocidadDeSprint;
	public int vida;

	private Rigidbody2D rb; //Rigidbody2D del obstáculo
	private float velocidadActual;
	private bool debeDetenerse;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		velocidadActual = velocidadMov;
		debeDetenerse = true;
	}

	void FixedUpdate()
	{
		rb.velocity = Vector2.left * velocidadActual; //Le da la velocidad de movimiento al obstáculo
	}

	private void Update()
	{
		ChecarVida();

		if (transform.position.x <= 9f && debeDetenerse)
		{
			debeDetenerse = false;
			StartCoroutine(EsperarSprint(1.5f));
		}

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

	IEnumerator EsperarSprint(float _tiempo)
	{
		velocidadActual = 0f;
		yield return new WaitForSeconds(_tiempo);
		velocidadActual = velocidadMov * velocidadDeSprint;
	}
}
