using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    //public float fuerzaDeFlote;
    public float fuerzaDeSumergir;

    private bool sumergiendose = false;

    // Update is called once per frame
    void Update()
    {
        #region MOVIMIENTO VERSIÓN 2
        if (Input.GetKeyDown(KeyCode.Mouse1) )
        {
            rb.velocity = Vector2.down * fuerzaDeSumergir;
        }
        #endregion

    }

}
