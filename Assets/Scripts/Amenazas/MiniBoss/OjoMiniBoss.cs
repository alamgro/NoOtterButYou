using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjoMiniBoss : MonoBehaviour
{
    //[HideInInspector]
    public bool abrirOjo;
    public float timerOjo;
    public int vida;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0f, 0f, 0f);
        abrirOjo = false;
    }

    void Update()
    {
        ChecarVida();

        if (abrirOjo)
        {
            spriteRenderer.color = new Color(150f, 35f, 200f); //Cambiar color [aquí debe ir la lógica de abrir el ojo]

            //abrirOjo = false;
            timerOjo -= Time.deltaTime;
            if (timerOjo <= 0f)
            {
                spriteRenderer.color = new Color(0f, 0f, 0f); //Cambiar color [aquí debe ir la lógica de CERRAR el ojo]
                abrirOjo = false;
            }

        }
    }

    void ChecarVida()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (abrirOjo)
        {
            if (collision.gameObject.CompareTag("Piedra"))
            {
                vida--;
                print(vida);
            }
        }
    }
}
