using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
    public float speed, slide;
    private Vector3 mov, position;
    private Rigidbody rb;
    float angle;
    Quaternion rotation;
    // Use this for initialization
    void Start()  {
        rb = GetComponent<Rigidbody>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "ball")
    //    {
    //        var ball = collision.gameObject;
    //        ball.GetComponent<Rigidbody>().velocity += mov * slide;
    //        Debug.Log(mov);
    //        Debug.Log(slide);
    //        Debug.Log(ball.GetComponent<Rigidbody>().velocity);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        rotation = transform.rotation;
        position = transform.position;
        angle = rotation.w;
        if (Input.GetKey(KeyCode.B))
        {
            mov = new Vector3(-1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.forward * speed * 5 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.V))
        {
            mov = new Vector3(1, 0, 0);
            rb.transform.position += mov * speed * Time.deltaTime;
            //rb.transform.Rotate(Vector3.back * speed * 5 * Time.deltaTime);
        }
        else
        {
            mov = new Vector3(0, 0, 0);
        }

        rb.transform.position += new Vector3(Input.GetAxis("left_joy_Hp2"), 0, 0) * speed * Time.deltaTime;
        rb.transform.Rotate(new Vector3(0, Input.GetAxis("right_joy_Hp2"), 0) * speed * 10 * Time.deltaTime);

        if (Input.GetKey(KeyCode.N))
        {
            rb.transform.Rotate(-Vector3.up * speed * 10 * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.M))
        {
            rb.transform.Rotate(Vector3.up * speed * 10 * Time.deltaTime);
        }

        if (angle > .30f)
            rb.transform.rotation = Quaternion.Euler(0, 145.1f, 0);
        else if (angle < -.30f)
            rb.transform.rotation = Quaternion.Euler(0, 214.9f, 0);
        if (position.x < -7)
            rb.transform.position = new Vector3(-6.9f, rb.transform.position.y, rb.transform.position.z);
        else if (position.x > 7)
            rb.transform.position = new Vector3(6.9f, rb.transform.position.y, rb.transform.position.z);
    }
}
