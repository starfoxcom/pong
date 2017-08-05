﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    private float speed = 5;
    private Vector3 mov;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            mov = new Vector3(-1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.forward * speed * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.B))
        {
            mov = new Vector3(1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.back * speed * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.M))
        {
            rb.transform.Rotate(-Vector3.up * speed * 10 * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.N))
        {
            rb.transform.Rotate(Vector3.up * speed * 10 * Time.deltaTime);
        }
    }
}
