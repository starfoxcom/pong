using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {


    private Rigidbody rb;
    private float speed;
    private Vector3 dir;

    // Use this for initialization
	void Start () {
        speed = 10;
        rb = GetComponent<Rigidbody>();
        dir = new Vector3(0f, 0f, 1.0f);
        dir.Normalize();
        GetComponent<Rigidbody>().velocity += dir * speed;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
