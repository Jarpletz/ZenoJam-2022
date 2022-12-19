using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
   Transform playerPos;
   Camera cam;
   Vector3 lerpPos;
   float xPos;
   float cameraWidth;
   
   [SerializeField]float yOffset;
   [SerializeField] Vector2 xBounds;
   [SerializeField] float lerpSpeed;

   void Start()
   {
      playerPos = GameObject.FindWithTag("Player").transform;
      cam = Camera.main;
   }

   // Update is called once per frame
   void Update()
   {
      cameraWidth= cam.orthographicSize * cam.aspect;

      xPos=playerPos.position.x;

      if (xPos < xBounds.x + cameraWidth)
      {
         xPos = xBounds.x + cameraWidth;
      }
      else if (xPos > xBounds.y - cameraWidth)
      {
         xPos = xBounds.y - cameraWidth;
      }

      lerpPos.Set(xPos, playerPos.position.y+yOffset, -1);

      transform.position= Vector3.Lerp(transform.position, lerpPos, lerpSpeed);

   }
}
