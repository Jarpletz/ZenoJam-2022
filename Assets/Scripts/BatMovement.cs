using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BatMovement : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] Transform[] points;
   [SerializeField] float speed;
   [SerializeField] float distanceThreshold;
   private bool alive = true;
   GameObject Player;
   [SerializeField] float slownessMultiplier = 2;





   Vector3 direction;
   Vector3 scaleFlip;

   int pointDir=1;
   int currentTarget=0;

   EnemyHealth health;
   Rigidbody2D rb;
   private Vector2 netForce;
   private int deadLayer;


   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
// <<<<<<< HEAD
      deadLayer = LayerMask.NameToLayer("Dead");
// =======
//       health = GetComponent<EnemyHealth>();
//
// >>>>>>> 27553bbc65df17634a657c66d3d754359fc1be5c
      transform.position = points[0].position;
      Player = GameObject.FindWithTag("Player");

   }

   // Update is called once per frame
   void Update()
   {
// <<<<<<< HEAD
      if (alive)
// =======
//       if (!health.isAlive)
//       {
//          Destroy(gameObject);
//       }
//
//       if (Vector3.Distance(transform.position, points[currentTarget].position) < distanceThreshold)
//       {//If close to the targeted point
//
//          if(currentTarget == 0 && pointDir == -1)
//          {
//             pointDir = 1;
//          }//If has reached the first point, turn around
//          else if(currentTarget == points.Length - 1 && pointDir == 1)
//          {
//             pointDir = -1;
//          }//If has reached the last point, turn around
//
//          currentTarget += pointDir;
//       }
//
//       direction= Vector3.MoveTowards(transform.position, points[currentTarget].position, speed*Time.deltaTime);
//
//       transform.position = direction;
//
//       if (points[currentTarget].position.x > transform.position.x)
// >>>>>>> 27553bbc65df17634a657c66d3d754359fc1be5c
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
         alive = false;

         //Do What happens if it hits the player here
      }

      if (collision.gameObject.CompareTag("Flare"))
      {
         alive = false;
      }
   }
   

}
