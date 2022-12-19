using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareCollision : MonoBehaviour
{
   [SerializeField] float maxTimeAlive;
   [SerializeField] float triggerRadius = 5f;

   [Header("Particles")]
   [SerializeField] ParticleSystem flightParticles;
   [SerializeField] ParticleSystem explosionParticles;

   Rigidbody2D rb;
   CircleCollider2D cd;

   float timeAlive;
   bool hasCollided;

   void Start()
   {
      rb=GetComponent<Rigidbody2D>();
      cd=GetComponent<CircleCollider2D>();
   }

   // Update is called once per frame
   void Update()
   {
      timeAlive+=Time.deltaTime;
      if(timeAlive>maxTimeAlive || hasCollided)
      {
         Destroy(gameObject, 2);
      }

   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      hasCollided = true;
      rb.isKinematic = true;
      rb.velocity = Vector3.zero;
      GetComponent<SpriteRenderer>().enabled = false;

      cd.isTrigger = true;
      cd.radius = triggerRadius;

      flightParticles.Stop();
      explosionParticles.Play();

      EnemyHealth eHealth = collision.gameObject.GetComponent<EnemyHealth>();
      if (eHealth != null)
      {
         eHealth.isAlive = false;
      }
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      EnemyHealth eHealth = collision.gameObject.GetComponent<EnemyHealth>();
      if (eHealth != null)
      {
         eHealth.isAlive = false;
      }
   }
}
