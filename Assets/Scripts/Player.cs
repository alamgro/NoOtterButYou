using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    public float fuerzaDeFlote; //Fuerza con la que el Player es empujado a la superficie constantemente
    public float fuerzaDeSumergir;

    private bool sumergiendose;

    // Start is called before the first frame update
    void Start()
    {
        sumergiendose = false;
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        #region MOVIMIENTO VERSIÓN 1
        /*
        //El click derecho te hace ir hacia abajo, si lo sueltas empiezas a flotar
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fuerzaVertical = -fuerzaDeFlote;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            fuerzaVertical = fuerzaDeFlote;
        }
        */
        #endregion

        //rb.velocity = Vector2.up * fuerzaVertical;

        

        #region MOVIMIENTO VERSIÓN 2
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Sumergirse(0.3f));
            //rb.velocity = Vector2.down * fuerzaDeSumergir;
        }
        #endregion

        if (!sumergiendose)
        {
            rb.velocity = Vector2.up * fuerzaDeFlote;
        }
    }

    

    IEnumerator Sumergirse(float _tiempo)
    {
        sumergiendose = true;
        //rb.velocity = Vector2.zero;
        //rb.AddForce(Vector2.down * fuerzaDeSumergir, ForceMode2D.Impulse);
        rb.velocity = Vector2.down * fuerzaDeSumergir;
        yield return new WaitForSeconds(_tiempo);
        sumergiendose = false;
    }

    
    
}
