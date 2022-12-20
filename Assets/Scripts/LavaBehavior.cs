using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LavaBehavior : MonoBehaviour
{
   LevelGenerator levelGenerator;
   Vector3 nextPos;

   [SerializeField] float yVelocity;
   [SerializeField] float yOffset;


   void Start()
   {
      levelGenerator = GameObject.FindWithTag("LevelGenerator").GetComponent<LevelGenerator>();
      

   }

   // Update is called once per frame
   void Update()
   {
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
