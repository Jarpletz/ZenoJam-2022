using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
   // Start is called before the first frame update
   [SerializeField] Transform[] points;
   [SerializeField] float speed;
   [SerializeField] float distanceThreshold;



   Vector3 direction;
   Vector3 scaleFlip;

   int pointDir=1;
   int currentTarget=0;

   EnemyHealth health;
   Rigidbody2D rb;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      health = GetComponent<EnemyHealth>();

      transform.position = points[0].position;
   }

   // Update is called once per frame
   void Update()
   {
      if (!health.isAlive)
      {
         Destroy(gameObject);
      }

      if (Vector3.Distance(transform.position, points[currentTarget].position) < distanceThreshold)
      {//If close to the targeted point

         if(currentTarget == 0 && pointDir == -1)
         {
            pointDir = 1;
         }//If has reached the first point, turn around
         else if(currentTarget == points.Length - 1 && pointDir == 1)
         {
            pointDir = -1;
         }//If has reached the last point, turn around

         currentTarget += pointDir;
      }

      direction= Vector3.MoveTowards(transform.position, points[currentTarget].position, speed*Time.deltaTime);

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
         //Do What happens if it hits the player here
      }
   }

}
