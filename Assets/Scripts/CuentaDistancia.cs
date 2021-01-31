using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CuentaDistancia : MonoBehaviour
{
    public float distanciaTotal; //Tamano total de barra 

    float tiempo;
    Image barraOxigeno;


    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        barraOxigeno = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        barraOxigeno.fillAmount = tiempo / distanciaTotal;

    }
    

   
    
}
