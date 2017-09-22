using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {

    int idplayer, idcourt=0, p1s=0, p2s=0;
    public float speed;
    public AudioClip sound;
    private Rigidbody rb;
    private Vector3 diry, diri, pos, topspin, glove, drop;
    public Text p1, p2;
    

    // Use this for initialization
    void Start () {

        p1.text = "player 1: " + p1s.ToString() + " player 2: " + p2s.ToString();
        p2.text = "player 1: " + p1s.ToString() + " player 2: " + p2s.ToString();
        diri = new Vector3(0f, 0f, Random.Range(-1f,1f));
        pos = GetComponent<Rigidbody>().position;
        rb = GetComponent<Rigidbody>();
        diry = new Vector3(0f, 0.4f, 0f);
        diri.Normalize();
        GetComponent<Rigidbody>().velocity = diri * speed;
        StartCoroutine(ballout());
        
    }


   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "court")
        {
            var court = collision.gameObject;
            idcourt = 1;

        }
        if (collision.gameObject.name == "p1")
        {
            var p1 = collision.gameObject;
            idcourt = 0;
            if(Input.GetButton("leftButton_p1") && Input.GetButton("rightButton_p1"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                drop = rb.velocity;
                drop.z = 8;
                drop.y = 4;
                rb.velocity = drop;
                Debug.Log("drop");
            }
            else if (Input.GetButton("leftButton_p1"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                topspin = rb.velocity;
                topspin.z = speed * 1.5f;
                topspin.y = 4.5f;
                rb.velocity = topspin;
                Debug.Log("topspin");
            }
            else if (Input.GetButton("rightButton_p1"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                glove = rb.velocity;

                glove.y = 4 * 2f;
                glove.z = 8;
                rb.velocity = glove;
                Debug.Log("glove");
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(sound);
                rb.velocity = ((p1.GetComponent<Rigidbody>().transform.forward + diry) * speed);
                Debug.Log("normal");
            }
            idplayer = 1;
        }
        if (collision.gameObject.name == "p2")
        {
            var p2 = collision.gameObject;
            idcourt = 0;
            if (Input.GetButton("leftButton_p2") && Input.GetButton("rightButton_p2"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                drop = rb.velocity;
                drop.z = -8;
                drop.y = 4;
                rb.velocity = drop;
                Debug.Log("drop");
            }
            else if(Input.GetButton("leftButton_p2"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                topspin = rb.velocity;
                topspin.z = -speed * 1.5f;
                topspin.y = 4.5f;
                rb.velocity = topspin;
                Debug.Log(topspin);
            }
            else if (Input.GetButton("rightButton_p2"))
            {
                GetComponent<AudioSource>().PlayOneShot(sound);

                glove = rb.velocity;

                glove.y = 4 * 2f;
                glove.z = -8;
                rb.velocity = glove;
                Debug.Log("glove");
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(sound);
                rb.velocity = -((-p2.GetComponent<Rigidbody>().transform.forward - diry) * speed);
                Debug.Log("normal");
            }
            idplayer = 2;
        }
        if (collision.gameObject.name == "out")
        {
            if (idplayer == 1 && idcourt == 1)
            {
                p1s++;

            }
            else if (idplayer == 1 && idcourt == 0)
            {
                p2s++;
            }
            if (idplayer == 2 && idcourt == 1)
            {
                p2s++;
            }
            else if (idplayer == 2 && idcourt == 0)
            {
                p1s++;
            }
            StartCoroutine(ballout());
        }


    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButton("PauseButton"))
        {
            Time.timeScale = 0.0f;
            //Debug.Log("pause");
        }
        if (Input.GetButton("Pause2Button"))
        {
            Time.timeScale = 1f;
            //Debug.Log("bye");
        }
        p1.text = "player 1: " + p1s.ToString() + " player 2: " + p2s.ToString();
        p2.text = "player 1: " + p1s.ToString() + " player 2: " + p2s.ToString();
    }
    IEnumerator ballout()
    {

        rb.position = pos;
        rb.velocity = Vector3.up * speed / 2;
        yield return new WaitForSeconds(1);
        diri = new Vector3(0f, 0f, Random.Range(-1f, 1f));
        diri.Normalize();
        rb.velocity = diri * speed;

    }
}
