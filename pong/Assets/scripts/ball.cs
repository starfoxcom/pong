using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {


    public float speed;
    private Rigidbody rb;
    private Vector3 diry, diri, pos, topspin, glove, drop;

    // Use this for initialization
	void Start () {
        
        diri = new Vector3(0f, 0f, Random.Range(-1f,1f));
        pos = GetComponent<Rigidbody>().position;
        rb = GetComponent<Rigidbody>();
        diry = new Vector3(0f, 0.4f, 0f);
        diri.Normalize();
        GetComponent<Rigidbody>().velocity = diri * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "p1")
        {
            var p1 = collision.gameObject;
            if(Input.GetButton("leftButton_p1") && Input.GetButton("rightButton_p1"))
            {
                drop = rb.velocity;
                drop.z = 8;
                drop.y = 4;
                rb.velocity = drop;
                Debug.Log("drop");
            }
            else if (Input.GetButton("leftButton_p1"))
            {
                topspin = rb.velocity;
                topspin.z = speed * 1.5f;
                topspin.y = 4.5f;
                rb.velocity = topspin;
                Debug.Log("topspin");
            }
            else if (Input.GetButton("rightButton_p1"))
            {
                glove = rb.velocity;

                glove.y = 4 * 2f;
                glove.z = 8;
                rb.velocity = glove;
                Debug.Log("glove");
            }
            else
            {
                rb.velocity = ((p1.GetComponent<Rigidbody>().transform.forward + diry) * speed);
                Debug.Log("normal");
            }

        }
        if (collision.gameObject.name == "p2")
        {
            var p2 = collision.gameObject;
            if (Input.GetButton("leftButton_p2") && Input.GetButton("rightButton_p2"))
            {
                drop = rb.velocity;
                drop.z = -8;
                drop.y = 4;
                rb.velocity = drop;
                Debug.Log("drop");
            }
            else if(Input.GetButton("leftButton_p2"))
            {
                topspin = rb.velocity;
                topspin.z = -speed * 1.5f;
                topspin.y = 4.5f;
                rb.velocity = topspin;
                Debug.Log(topspin);
            }
            else if (Input.GetButton("rightButton_p2"))
            {
                glove = rb.velocity;

                glove.y = 4 * 2f;
                glove.z = -8;
                rb.velocity = glove;
                Debug.Log("glove");
            }
            else
            {
                rb.velocity = -((-p2.GetComponent<Rigidbody>().transform.forward - diry) * speed);
                Debug.Log("normal");
            }
            //Debug.Log(rb.velocity);
            //Debug.Log(topspin);
        }
        if (collision.gameObject.name == "out")
        {
            rb.position = pos;
            diri = new Vector3(0f, 0f, Random.Range(-1f, 1f));
            diri.Normalize();
            rb.velocity = diri * speed;
            Debug.Log(speed);
        }


    }
    // Update is called once per frame
    void Update () {
        
        
		
	}
}
