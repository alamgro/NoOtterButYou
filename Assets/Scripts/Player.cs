using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadMov;

    private Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #region MOVIMIENTO LIBRE
        float ejeX = Input.GetAxisRaw("HorizontalWASD");
        float ejeY = Input.GetAxisRaw("VerticalWASD");
        Vector2 vectorMov = new Vector2(ejeX, ejeY).normalized;

        rb.velocity = vectorMov * velocidadMov;
        #endregion

    }

}
