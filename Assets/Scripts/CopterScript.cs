using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterScript : MonoBehaviour
{
    [SerializeField] float force = 1;
    [SerializeField] float defaltUpVolocity = 1;
    [SerializeField] private float verticalForceDamp = 1;
    private Vector2 netForce;
    private Vector2 upForce;
    Rigidbody2D rb;
    private bool checkVol = true;
    private Vector3 newScail;

    private int key;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        newScail = rb.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            key = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            key = -1;
        }
        
        netForce.x = force * Input.GetAxis("Horizontal");
        netForce.y = (force * Input.GetAxis("Vertical"))/verticalForceDamp;
        
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


