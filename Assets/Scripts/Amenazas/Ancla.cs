using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancla : MonoBehaviour
{
	public float velocidadMov;

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
		rb.velocity = Vector2.down * velocidadActual; //Le da la velocidad de movimiento al obstáculo
	}

	private void Update()
	{
		if(transform.position.y <= 5f && debeDetenerse)
        {
			debeDetenerse = false;
			StartCoroutine(EsperarCaida(1.5f));
        }

		if (transform.position.y <= -15f)
		{
			Destroy(gameObject);
		}

	}

	IEnumerator EsperarCaida(float _tiempo)
    {
		velocidadActual = 0f;
		yield return new WaitForSeconds(_tiempo);
		velocidadActual = velocidadMov;
    }

}
