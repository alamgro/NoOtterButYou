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
            int probabilidad = Random.Range(1, 100);

            if(probabilidad <= 45) //MEDIANO 45%
            {
                Instantiate(obstaculos[0], posicion, Quaternion.identity);
            }
            else if (probabilidad <= 50) //GRANDE O EXTRAÑO 10%
            {
                probabilidad = Random.Range(1, 50); //Calcular la probabilidad ahora para decidir cuál de los dos sale
                if(probabilidad <= 50)
                {
                    //GRANDE 50%
                    Instantiate(obstaculos[1], posicion, Quaternion.identity);
                }
                else
                {
                    //CARDUMEN 50%
                    Instantiate(obstaculos[2], posicion, Quaternion.identity);
                }
            }
            else if (probabilidad <= 66) //ANCLA 16%
            {
                posicion = new Vector2(Random.Range(-8f, 0f), 8f); //La lógica de generación del Ancla es diferente, aparece arriba
                Instantiate(obstaculos[3], posicion, Quaternion.identity);
            }
            else if (probabilidad <= 78) //#1 12%
            {

            }
            else if (probabilidad <= 90) //#2 12%
            {

            }
            else if (probabilidad <= 100) //#3 10%
            {

            }

            //Instantiate(obstaculos[randObs], posicion, Quaternion.identity);
            timer = frecuencia;
        }
    }
}
