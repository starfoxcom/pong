using System.Collections;
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
        if(Input.GetKey(KeyCode.Q))
        {
            mov = new Vector3(-1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.forward * speed * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            mov = new Vector3(1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.back * speed * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            rb.transform.Rotate(-Vector3.up * speed * 10 * Time.deltaTime);
            
        }
        else if(Input.GetKey(KeyCode.R))
        {
            rb.transform.Rotate(Vector3.up * speed * 10 * Time.deltaTime);
        }
        if (angle > .30f)
            rb.transform.rotation = Quaternion.Euler(0, 34.9f, 0);
        else if (angle < -.30f)
            rb.transform.rotation = Quaternion.Euler(0, -34.9f, 0);
        if (position.x < -7)
            rb.transform.position = new Vector3(-6.9f, rb.transform.position.y, rb.transform.position.z);
        else if(position.x > 7)
            rb.transform.position = new Vector3(6.9f, rb.transform.position.y, rb.transform.position.z);
    }
}
