using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareItemScript : MonoBehaviour
{
    GameManager gm;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 netForce;
    Transform PlayerPos;
    [SerializeField] float deadZone;


    
    [SerializeField] private float flareModifyer = 1;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        netForce[0] = 0;
        netForce[1] = -speed;
        rb.AddForce(netForce);
        
        if (transform.position.y < PlayerPos.position.y - deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("here");
        if (other.gameObject.CompareTag("Player"))
        {
            gm.flares += flareModifyer;
            Destroy(gameObject);
        }
    }
}
