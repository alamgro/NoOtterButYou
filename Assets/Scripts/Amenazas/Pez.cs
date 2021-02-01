using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pez : MonoBehaviour
{
	public int vida;

	private void Update()
	{
		ChecarVida();
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
