using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float velocidadGlobal;

    // Start is called before the first frame update
    void Start()
    {
        velocidadGlobal = 20f;   
    }

    // Update is called once per frame
    void Update()
    {
        print(velocidadGlobal);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            velocidadGlobal += 0.5f;
            if (velocidadGlobal < 0f)
            {
                velocidadGlobal = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            velocidadGlobal -= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();


    }
}
