using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterScript : MonoBehaviour
{
    public float force = 1;
    [SerializeField] private float verticalForceDamp = 1;
    private Vector2 netForce;
    Rigidbody2D rb;
    Collision coll;
    private bool checkVol = true;
    private Vector3 newScail;

    GameManager gameManager;
    
    private int key;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        newScail = rb.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            key = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            key = -1;
        }
        netForce[0] = force * Input.GetAxis("Horizontal");
        netForce[1] = (force * Input.GetAxis("Vertical"))/verticalForceDamp;
        
        
        if (key < 0 && !checkVol)
        {
            Flip();
            checkVol = true;
        }
        else if (key > 0 && checkVol)
        {
            Flip();
            checkVol = false;
        }
        
        rb.AddForce(netForce);
        
    }
    void Flip()
    {
        newScail.x *= -1;
        rb.transform.localScale = newScail;
    }

    
}


