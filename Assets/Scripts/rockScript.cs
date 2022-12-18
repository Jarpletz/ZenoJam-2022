using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Vector3 copterPoss;
    [SerializeField] private float deadZone = -50;
    Rigidbody2D rb;
    private Vector2 netForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        copterPoss = GameObject.FindWithTag("Player").transform.position;
        netForce[0] = 0;
        netForce[1] = speed;
        rb.AddForce(netForce);
        
        if (transform.position.y < copterPoss.y - 50)
        {
            Destroy(gameObject);
        }
    }
}

