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
            int randObs = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[randObs], posicion, Quaternion.identity);
            timer = frecuencia;
        }
    }
}
