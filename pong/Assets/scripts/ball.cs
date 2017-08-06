using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {


    public float speed;
    private Vector3 diry, diri, pos;

    // Use this for initialization
	void Start () {
        
        diri = new Vector3(0f, 0f, Random.Range(-1f,1f));
        pos = GetComponent<Rigidbody>().position;
        //while (diri.x != 0)
        //{
        //    diri.x = Random.Range(-1f, 1f);
        //}
      
        diry = new Vector3(0f, 0.4f, 0f);
        diri.Normalize();
        //diry.Normalize();
        GetComponent<Rigidbody>().velocity = diri * speed;
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "p1")
        {
            var p1 = collision.gameObject;
            GetComponent<Rigidbody>().velocity = ((p1.GetComponent<Rigidbody>().transform.forward + diry) * speed);

        }
        if (collision.gameObject.name == "p2")
        {
            var p2 = collision.gameObject;
            GetComponent<Rigidbody>().velocity = -((-p2.GetComponent<Rigidbody>().transform.forward - diry) * speed);
        }
        if (collision.gameObject.name == "out")
        {
            GetComponent<Rigidbody>().position = pos;
            diri = new Vector3(0f, 0f, Random.Range(-1f, 1f));
            diri.Normalize();
            GetComponent<Rigidbody>().velocity = diri * speed;
            Debug.Log(speed);
        }


    }
    // Update is called once per frame
    void Update () {
        
        
		
	}
}
