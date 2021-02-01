using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjoMiniBoss : MonoBehaviour
{
    [HideInInspector]
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
            spriteRenderer.color = new Color(1f, 1f, 1f); //Cambiar color [aquí debe ir la lógica de ABRIR el ojo]

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
            // [aquí debe ir la lógica de ojo DERROTADO / MUERTO]
            timerOjo = 0f; //Se queda en 0 para que cierre el ojo inmediatamente
            spriteRenderer.color = new Color(0.6f, 0.14f, 0.8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (abrirOjo)
        {
            if (collision.CompareTag("Piedra"))
            {
                vida--;
            }
        }
    }
}
