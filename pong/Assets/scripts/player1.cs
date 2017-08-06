﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour {
    public float speed;
    private Vector3 mov, position;
    private Rigidbody rb;
    float angle;
    Quaternion rotation;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation;
        position = transform.position;
        angle = rotation.y;

        rb.transform.position += new Vector3(Input.GetAxis("left_joy_Hp1"), 0, Input.GetAxis("left_joy_Vp1")) * speed * Time.deltaTime;
        rb.transform.Rotate(new Vector3(0, Input.GetAxis("right_joy_Hp1"), 0) * speed * 10 * Time.deltaTime);

        if (angle > .30f)
            rb.transform.rotation = Quaternion.Euler(0, 34.9f, 0);
        else if (angle < -.30f)
            rb.transform.rotation = Quaternion.Euler(0, -34.9f, 0);
        if (position.x < -8)
            rb.transform.position = new Vector3(-7.9f, rb.transform.position.y, rb.transform.position.z);
        else if(position.x > 8)
            rb.transform.position = new Vector3(7.9f, rb.transform.position.y, rb.transform.position.z);
        if (position.z < -12)
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, -11.9f);
        else if (position.z > -2)
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, -2.1f);

    }
}
