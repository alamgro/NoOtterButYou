using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public float vidaMax; //Tamano total de barra 
    public float vidaActual; //Vida que tiene en ese momento

    Image barraVida;

    void Start()
    {
        barraVida = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9)) //testeo in-game
            vidaActual -= 1f; 

        if(vidaActual < 0)
        {
            //Lógica para cuando pierden todas las vidas
        }

        barraVida.fillAmount = vidaActual / vidaMax;
    }

}
