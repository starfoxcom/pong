using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {


    public float speed;
    private Rigidbody rb;
    private Vector3 diry, diri, pos, topspin;

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
        if(collision.gameObject.name == "p1")
        {
            var p1 = collision.gameObject;
            if (Input.GetKey(KeyCode.T))
            {
                topspin = rb.velocity;
                topspin.z *= 1.5f;
                topspin.y = 4;
                if (topspin.z > 14.5f)
                    topspin.z = 14.5f;
                rb.velocity = topspin;
            }
            else
                rb.velocity = ((p1.GetComponent<Rigidbody>().transform.forward + diry) * speed);
            //Debug.Log(rb.velocity);
            //Debug.Log(topspin);
        }
        if (collision.gameObject.name == "p2")
        {
            var p2 = collision.gameObject;
            if (Input.GetKey(KeyCode.Comma))
            {
                topspin = rb.velocity;
                topspin.z *= 1.5f;
                topspin.y = 4;
                if (topspin.z < -14.5f)
                    topspin.z = -14.5f;
                rb.velocity = topspin;
            }
            else
                rb.velocity = -((-p2.GetComponent<Rigidbody>().transform.forward - diry) * speed);
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
