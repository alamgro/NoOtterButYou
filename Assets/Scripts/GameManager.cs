using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float velocidadGlobal;
    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        velocidadGlobal = 20f;
        pause = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                Escenas.Pause();
            }
            else
                Escenas.PauseDestry();

            pause = !pause;
        }

       // print("Pause esta en :" + pause);




    }
}
