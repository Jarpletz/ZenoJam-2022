using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update

   LineRenderer lineRenderer;
   Rigidbody2D rb;
   GameManager gm;

   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      lineRenderer=GetComponentInChildren<LineRenderer>();
      gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

   }

   // Update is called once per frame
   void Update()
   {
        
   }
}
