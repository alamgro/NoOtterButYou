using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fuerzaDeFlote; //Fuerza con la que el Player es empujado a la superficie constantemente

    public Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    private float fuerzaVertical;

    // Start is called before the first frame update
    void Start()
    {
        fuerzaVertical = fuerzaDeFlote; //Por defecto va a flotar
        //this.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {

        //El click derecho te hace ir hacia abajo, si lo sueltas empiezas a flotar
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //this.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
            fuerzaVertical = -fuerzaDeFlote;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //this.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
            fuerzaVertical = fuerzaDeFlote;
        }

        rb.velocity = Vector2.up * fuerzaVertical;
    }

    
    
}
