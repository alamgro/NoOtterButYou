﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float velocidadGlobal;
    public static int jugadoresIncapacitados; //Es la cantidad de jugadores que están incapacitados, si hay dos, se acaba el juego
    public static int jugadoresVivos; //Es la cantidad de jugadores que aún están vivos, si no queda ninguno, se acaba el juego

    public static bool pause;
    bool escenaFin;

    public static bool mappingAbierto;
    public static bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        velocidadGlobal = 20f;
        jugadoresVivos = 2;
        jugadoresIncapacitados = 0;
        pause = false;
        escenaFin = false;

        gameOver = true;
        mappingAbierto = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameOver)
        {
            if (!pause)
            {
                Escenas.Pause();
                mappingAbierto = false;
            }
            else
            {
                Escenas.PauseDestroy();
            }
            if (mappingAbierto)
                EscenasAdditive.MappingAdditiveDestroy();

            pause = !pause;
        }

        //Si los dos jugadores están incapacitados se acaba el juego, o también si no quedan más jugadores vivos.
        if(jugadoresIncapacitados == 2 || jugadoresVivos == 0)
        {
            
            //GameOver
            if(!escenaFin)
            {
                Escenas.GameOver();
                escenaFin = true;
            }

        }

        // print("Pause esta en :" + pause);

    }
}
