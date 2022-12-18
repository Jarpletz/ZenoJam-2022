using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareCollision : MonoBehaviour
{
   [SerializeField] float maxTimeAlive;

   Rigidbody2D rb;

   float timeAlive;
   bool hasCollided;

   void Start()
   {
      rb=GetComponent<Rigidbody2D>();
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
      GetComponent<Collider2D>().enabled = false;
      rb.velocity = Vector3.zero;

   }
}
