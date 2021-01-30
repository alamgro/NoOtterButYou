using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraOxigeno : MonoBehaviour
{
    public float oxigenoMax; //Tamano total de barra 
    public float oxigenoActual; //El oxigendo o vida que tiene en ese momento y lo lleva el Player
    public GameObject barraVidaObj;

    Image barraOxigeno;
    private BarraVida barraVidaComp;

    void Start()
    {
        barraOxigeno = GetComponent<Image>();
        barraVidaComp = barraVidaObj.GetComponent<BarraVida>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) //testeo in  game
            oxigenoActual -= 10f;*/

        barraOxigeno.fillAmount = oxigenoActual / oxigenoMax;

        //Si el oxígeno llega a 0, pierdes una vida y se te reinicia el oxígeno a 100%
        if(oxigenoActual <= 0f)
        {
            barraVidaComp.vidaActual -= 1f; //Resta una vida
            oxigenoActual = oxigenoMax; //Reset del oxígeno al máximo
        }
    }
}
