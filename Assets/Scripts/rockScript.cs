using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] float deadZone;
   [SerializeField] ParticleSystem destructionParticles;

   Transform PlayerPos;


   Rigidbody2D rb;
   Collider2D boulderCollider;
   SpriteRenderer sp;

   private Vector2 netForce;
   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      boulderCollider = GetComponent<Collider2D>();
      sp= GetComponent<SpriteRenderer>();
      PlayerPos = GameObject.FindWithTag("Player").transform;
   }

   // Update is called once per frame
   void Update()
   {
        
      netForce[0] = 0;
      netForce[1] = speed;
      rb.AddForce(netForce);
        
      if (transform.position.y < PlayerPos.position.y - deadZone)
      {
         Destroy(gameObject);
      }
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      Debug.Log("BOOM");
      boulderCollider.enabled = false;
      sp.enabled = false;
      destructionParticles.Play();
      Destroy(gameObject, 1);
   }


}

