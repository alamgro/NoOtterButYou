using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraOxigeno : MonoBehaviour
{
    public float oxigenoMax; //Tamano total de barra 
    public float oxigenoActual; //El oxigendo o vida que tiene en ese momento y lo lleva el Player

    Image barraOxigeno;

    //public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        barraOxigeno = GetComponent<Image>();
        //oxigenoActual = player.GetComponent<Player>().oxigenoVida;

        // player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) //testeo in  game
            oxigenoActual -= 10f;*/

        barraOxigeno.fillAmount = oxigenoActual / oxigenoMax;
    }
}
