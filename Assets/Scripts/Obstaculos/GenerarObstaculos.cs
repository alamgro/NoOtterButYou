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
        timer = frecuencia;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Vector2 posicion = new Vector2(10f, Random.Range(coordMin, coordMax));
            int posibilidad = Random.Range(1, 100);

            if (posibilidad <= 15)
            {
                //CHICO
                Instantiate(obstaculos[0], posicion, Quaternion.identity);
            }
            else if(posibilidad <= 65)
            {
                //MEDIANO
                Instantiate(obstaculos[1], posicion, Quaternion.identity);
            }
            else if (posibilidad <= 75)
            {
                //GRANDE O EXTRAÑO
                posibilidad = Random.Range(1, 50);
                if(posibilidad <= 50)
                {
                    //GRANDE
                    Instantiate(obstaculos[2], posicion, Quaternion.identity);
                }
                else
                {
                    //CARDUMEN
                }
            }
            else if (posibilidad <= 100)
            {
                //ANCLA
                posicion = new Vector2(Random.Range(-8f, 0f), 8f); //La lógica de generación del Ancla es diferente, aparece arriba
                Instantiate(obstaculos[4], posicion, Quaternion.identity);
            }

            //Instantiate(obstaculos[randObs], posicion, Quaternion.identity);
            timer = frecuencia;
        }
    }
}
