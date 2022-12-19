using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BatMovement : MonoBehaviour
{
  
   [Header ("Movement")]
   [SerializeField] Transform[] points;
   [SerializeField] float speed;
   [SerializeField] float distanceThreshold;
   [SerializeField] float slownessMultiplier = 2;
   GameObject Player;
   GameManager gm;
   Vector3 direction;
   Vector3 scaleFlip;
   int pointDir=1;
   int currentTarget=0;
   EnemyHealth health;
   Rigidbody2D rb;
   private Collider2D col;
   private Vector2 netForce;
   private int deadLayer;


   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      col = GetComponent<Collider2D>();
      health = GetComponent<EnemyHealth>();
      transform.position = points[0].position;
      Player = GameObject.FindWithTag("Player");
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

   }

   // Update is called once per frame
   void Update()
   {
      if (health.isAlive)
      {
         if (Vector3.Distance(transform.position, points[currentTarget].position) < distanceThreshold)
         {
            //If close to the targeted point

            if (currentTarget == 0 && pointDir == -1)
            {
               pointDir = 1;
            } //If has reached the first point, turn around
            else if (currentTarget == points.Length - 1 && pointDir == 1)
            {
               pointDir = -1;
            } //If has reached the last point, turn around

            currentTarget += pointDir;
         }

         direction = Vector3.MoveTowards(transform.position, points[currentTarget].position, speed * Time.deltaTime);

         transform.position = direction;

         if (points[currentTarget].position.x > transform.position.x)
         {
            scaleFlip.Set(1, 1, 1);
         }
         else
         {
            scaleFlip.Set(-1, 1, 1);
         }

         transform.localScale = scaleFlip;
      }
      else
      {
         
         col.enabled = false;
         rb.rotation = 180;
         netForce[0] = 0;
         netForce[1] = -2;
         rb.AddForce(netForce);
         gameObject.layer = deadLayer;
      }
   }

   private void OnDrawGizmos()
   {
      for(int i=1; i < points.Length; i++)
      {
         Gizmos.DrawLine(points[i-1].position, points[i].position);
      }
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         Player.GetComponent<Rigidbody2D>().velocity /= slownessMultiplier;
         health.isAlive = false;
         //Do What happens if it hits the player here
      }

      if (collision.gameObject.CompareTag("Flare"))
      {
         health.isAlive = false;
      }
   }
}
