using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehavior : MonoBehaviour
{
   LevelGenerator levelGenerator;
   Transform playerPos;
   Vector3 nextPos;
   SoundManager sound;

   [SerializeField] float yVelocity;
   [SerializeField] float yOffset;

   [SerializeField] float minPlayerY;
   void Start()
   {
      levelGenerator = GameObject.FindWithTag("LevelGenerator").GetComponent<LevelGenerator>();
      playerPos = GameObject.FindWithTag("Player").transform;
      sound=GetComponent<SoundManager>();

      
   }

   // Update is called once per frame
   void Update()
   {
      if (playerPos.position.y < minPlayerY)
      {
         return;
      }//Only raise the lava if the player is above the start level

      nextPos.Set(0, transform.position.y + (yVelocity * Time.deltaTime), 0);
      //Move Lava up

      if(transform.position.y < levelGenerator.ActiveLevels[0].transform.position.y-yOffset)
      {
         nextPos.Set(0, levelGenerator.ActiveLevels[0].transform.position.y - yOffset, 0);
      }
      //If below lowest generated level, move it up to the bottom of the level
      transform.position = nextPos;


   }

   

}
