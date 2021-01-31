using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour
{
    public float coordMin;
    public float coordMax;
    public GameObject[] obstaculos;
    public float frecuencia;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2f; //El primer obstáculo se genera a partir de este segundo
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Vector2 posicion = new Vector2(18f, Random.Range(coordMin, coordMax));
            int probabilidad = Random.Range(1, 100);

            if(probabilidad <= 45) //MEDIANO 45%
            {
                probabilidad = Random.Range(1, 100);
                if(probabilidad <= 33)
                    Instantiate(obstaculos[0], posicion, Quaternion.identity); //Basura 1
                else if (probabilidad <= 66)
                    Instantiate(obstaculos[5], posicion, Quaternion.identity); //Basura 2
                else
                    Instantiate(obstaculos[6], posicion, Quaternion.identity); //Basura 3
            }
            else if (probabilidad <= 60) //CARDUMEN 15%
            {
                Instantiate(obstaculos[1], posicion, Quaternion.identity);
            }
            else if (probabilidad <= 76) //ANCLA 16%
            {
                posicion = new Vector2(Random.Range(-11f, 0f), 11f); //La lógica de generación del Ancla es diferente, aparece arriba
                Instantiate(obstaculos[2], posicion, Quaternion.identity);
            }
            else if (probabilidad <= 88) //#PEZ ESPADA 12%
            {
                Instantiate(obstaculos[3], posicion, Quaternion.identity);
            }
            else if (probabilidad <= 100) //STALKER 12%
            {
                Instantiate(obstaculos[4], posicion, Quaternion.identity);
            }

            //Instantiate(obstaculos[randObs], posicion, Quaternion.identity);
            timer = frecuencia;
        }
    }
}
