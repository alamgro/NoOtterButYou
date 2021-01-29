using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarraOxigeno : MonoBehaviour
{
    private float oxigenoMax;
    public float oxigenoActual;

    Image barraOxigeno;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        barraOxigeno = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //oxigenoActual = player.oxigeno;
        barraOxigeno.fillAmount = oxigenoActual / oxigenoMax;
    }
}
