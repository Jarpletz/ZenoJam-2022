using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagtite : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask raycastLayer;
    [SerializeField] float deadZone;
    [SerializeField] private float damage;
    [SerializeField] ParticleSystem destructionParticles;
    Transform PlayerPos;
    GameManager gm;
    Rigidbody2D rb;
    Collider2D stalalgtiteCollider;
    SpriteRenderer sp;
    private Collider2D playerCol;
    private Vector2 netForce;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stalalgtiteCollider = GetComponent<Collider2D>();
        sp= GetComponent<SpriteRenderer>();
        PlayerPos = GameObject.FindWithTag("Player").transform;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        playerCol = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 50, raycastLayer);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point);
            if (hit.collider == playerCol)
            {
                print("here");
                rb.isKinematic = false;
                netForce[0] = 0;
                netForce[1] = -speed;
                rb.AddForce(netForce);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.up = Vector3.up;
        rb.angularVelocity = 0;
        stalalgtiteCollider.enabled = false;
        sp.enabled = false;
        destructionParticles.Play();
        Destroy(gameObject, 1);

        if (collision.gameObject.CompareTag("Player"))
        {
            gm.health -= damage;
        }
    }
}
