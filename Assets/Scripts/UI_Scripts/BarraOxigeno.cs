using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraOxigeno : MonoBehaviour
{
    public float oxigenoMax; //Tamano total de barra 
    public float oxigenoActual; //El oxigendo o vida que tiene en ese momento y lo lleva el Player
    [HideInInspector]
    public bool quitarVida;

    public Image barraOxigeno;

    void Start()
    {
        barraOxigeno = GetComponent<Image>();
        quitarVida = false;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha8)) //testeo in  game
            oxigenoActual -= 10f;*/

        barraOxigeno.fillAmount = oxigenoActual / oxigenoMax;

        //Si el oxígeno llega a 0, pierdes una vida y se te reinicia el oxígeno a 100%
        if (quitarVida)
        {
            BarraVida.vidaActual -= 1f; //Resta una vida
            quitarVida = false; //Ponemos el oxígeno en una cantidad muy pequeña pero diferente de 0 para que no vuelva a entrar a este if
            //oxigenoActual = oxigenoMax; //Reset del oxígeno al máximo (POR AHORA NO DEBE HACERLO ÉL MISMO
        }
    }

}
