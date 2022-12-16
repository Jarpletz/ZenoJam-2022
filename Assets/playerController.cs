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
      rb = getComponent<Rigidbody2D>();
      gm = GameObject.findWithTag("gameControler").getComponentin<GameManager>();

   }

   // Update is called once per frame
   void Update()
   {
        
   }
}
