using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterScript : MonoBehaviour
{
    [SerializeField] float force = 1;
    [SerializeField] private float defaltUpVolocity = 1;
    private Vector2 netForce;
    private Vector2 upForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        netForce.x = force * Input.GetAxis("Horizontal");
        netForce.y = force * Input.GetAxis("Vertical");
        upForce.y = defaltUpVolocity;
        rb.AddForce(upForce);
        rb.AddForce(netForce);
    }
}
