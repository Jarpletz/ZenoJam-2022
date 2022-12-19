using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareLauncher : MonoBehaviour
{
   [SerializeField] float lerpSpeed;
   [SerializeField] float launchForce;
   [SerializeField] GameObject flareObject;

   Vector3 mousePos;
   Vector2 DirToMouse;

   GameManager gm;

   private void Start()
   {
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

   }

   private void Update()
   {
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      DirToMouse = (Vector2)mousePos-(Vector2)transform.position;
      DirToMouse.Normalize();

      transform.up =Vector2.Lerp(transform.up,DirToMouse,lerpSpeed);
      //Debug.DrawRay(transform.position,transform.up*10);

      if (Input.GetMouseButtonDown(0) && gm.flares>0)
      {
         GameObject flare = Instantiate(flareObject);
         flare.transform.position = transform.position;
         flare.GetComponent<Rigidbody2D>().AddForce(DirToMouse * launchForce, ForceMode2D.Impulse);
         gm.flares--;
      }
   }
}
