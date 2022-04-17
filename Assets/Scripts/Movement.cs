﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bc;
    Vector3 moveXMent;
    public float speed;
    public float jumpVel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove();
    }

    void playerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveXMent = new Vector3(moveX, 0, moveY);
        transform.Translate(moveXMent * speed * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(bc.bounds.center, transform.TransformDirection(Vector3.down), 5))
        {
            rb.velocity = Vector3.up * jumpVel;
        }
    }

}