using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardumen : MonoBehaviour
{
	public float velocidadMov;
	public float velocidadSprint;

	private Rigidbody2D rb; //Rigidbody2D del obstáculo
	private float velocidadActual;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		velocidadActual = velocidadSprint;
	}

	void Update()
    {
        if(transform.position.x <= 3.5f)
        {
			velocidadActual = velocidadMov;
        }

		if (transform.position.x <= -20f)
		{
			Destroy(gameObject);
		}
	}

    void FixedUpdate()
	{
		rb.velocity = Vector2.left * velocidadActual; //Le da la velocidad de movimiento al obstáculo
	}

}
