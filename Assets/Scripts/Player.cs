﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb; //RigidBody del OBJETO PADRE (IMPORTANTE)
    public float fuerzaDeSumergir;
    public float fuerzaSubidaExtra;

    void Update()
    {
        #region MOVIMIENTO VERSIÓN 2
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.down * fuerzaDeSumergir;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, 0f);
        }
        #endregion

        if (rb.velocity.y > 0.1f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y + fuerzaSubidaExtra);
        }

    }

}
