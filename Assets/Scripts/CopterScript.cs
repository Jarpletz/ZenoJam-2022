using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterScript : MonoBehaviour
{
   public float force = 1;
   [SerializeField] private float verticalForceDamp = 1;
   [SerializeField] Vector2 volumeRange;
   [SerializeField] float maxVelocity;

    

   Rigidbody2D rb;
   Animator animator;
   AudioSource sound;


   private Vector2 netForce;
   private bool checkVol = true;
   private Vector3 newScail;

   GameManager gameManager;

   private int key;
   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
      sound = GetComponent<AudioSource>();
      gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
      newScail = rb.transform.localScale;
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      //Get the right volume for the chopper ambient noise:

      sound.volume = Mathf.Lerp(0, 1, rb.velocity.magnitude / maxVelocity);
      sound.volume = Mathf.Clamp(sound.volume, volumeRange.x, volumeRange.y);


      //lock movement if game has not begun
      if (!gameManager.hasStartedGame)
      {
         return;
      }
      else
      {
         animator.SetBool("hasStarted", true);
      }

      if (Input.GetAxis("Horizontal") > 0)
      {
         key = 1;
      }
      else if (Input.GetAxis("Horizontal") < 0)
      {
         key = -1;
      }
      netForce[0] = force * Input.GetAxis("Horizontal");
      netForce[1] = (force * Input.GetAxis("Vertical"))/verticalForceDamp;
        
        
      if (key < 0 && !checkVol)
      {
         Flip();
         checkVol = true;
      }
      else if (key > 0 && checkVol)
      {
         Flip();
         checkVol = false;
      }
        
      rb.AddForce(netForce);


      
   }
   void Flip()
   {
      newScail.x *= -1;
      rb.transform.localScale = newScail;
   }

    
}


