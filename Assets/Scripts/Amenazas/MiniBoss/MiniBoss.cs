using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    public OjoMiniBoss[] ojos;
    public GameObject proyectil;

    private int ojoRand;
    private bool debeAbrirUnOjo;
    private float timerParaAbrirOjo;
    private float timerAtacar;

    // Start is called before the first frame update
    void Start()
    {
        timerParaAbrirOjo = 2f;
        debeAbrirUnOjo = true;
    }

    // Update is called once per frame
    void Update()
    {
        AbrirOjo();
        Atacar();
    }

    void Atacar()
    {
        timerAtacar -= Time.deltaTime;
        Vector2 origenProyectil = new Vector2(11f, Random.Range(-6.5f, 6.5f));
        Instantiate(proyectil, origenProyectil, Quaternion.identity);
    }

    void AbrirOjo()
    {
        timerParaAbrirOjo -= Time.deltaTime; //Este timer representa el tiempo entre ojo y ojo abierto
        if (timerParaAbrirOjo <= 0)
        {
            //Verifica si es momento de abrir un ojo o no
            if (debeAbrirUnOjo)
            {
                debeAbrirUnOjo = false; //Esto para que el proceso de este IF solo se haga una vez hasta que el ojo elegido se cierre de nuevo

                //Debe elegir un ojo al azar, pero se asegura de que el elegido no haya sido derrotado antes.
                do
                {
                    ojoRand = Random.Range(0, ojos.Length);
                } while (ojos[ojoRand].vida <= 0);

                print(ojoRand);

                ojos[ojoRand].timerOjo = Random.Range(2.5f, 4f); //Es el tiempo que se mantendrá abierto el primero ojo que se elija
                ojos[ojoRand].abrirOjo = true; //Abrir uno de los ojos al azar
            }
            else
            {
                if (ojos[ojoRand].timerOjo <= 0f) //Para este punto ya debió cerrar el ojo en el script "OjoMiniBoss.cs"
                {
                    print("otra iteración");
                    timerParaAbrirOjo = Random.Range(0.5f, 2f); //Lo que salga aquí es lo que tardará en abrir otro ojo
                    debeAbrirUnOjo = true;
                }
            }
        }
    }
}
