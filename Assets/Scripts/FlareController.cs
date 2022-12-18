using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareController : MonoBehaviour
{
   [SerializeField] float lerpSpeed;

   Vector3 mousePos;
   Vector2 DirToMouse;

   private void Update()
   {
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      DirToMouse = (Vector2)mousePos-(Vector2)transform.position;
      DirToMouse.Normalize();

      transform.up =Vector2.Lerp(transform.up,DirToMouse,lerpSpeed);
      //Debug.DrawRay(transform.position,transform.up*10);
   }
}
