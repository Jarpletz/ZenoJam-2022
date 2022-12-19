using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LavaBehavior : MonoBehaviour
{
   GameManager gm;
   LevelGenerator levelGenerator;
   GameObject Player;
   Vector3 nextPos;

   [SerializeField] float damagePerSecond;
   [SerializeField] float yVelocity;
   [SerializeField] float yOffset;

   [SerializeField] float slownessMultiplier;

   void Start()
   {
      levelGenerator = GameObject.FindWithTag("LevelGenerator").GetComponent<LevelGenerator>();
      Player = GameObject.FindWithTag("Player");
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

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

   private void OnTriggerEnter2D(Collider2D collision)
   {//If the Player enters the Lava
      if (collision.gameObject.CompareTag("Player"))
      {
         Player.GetComponent<Rigidbody2D>().velocity /= slownessMultiplier;
         Player.GetComponent<CopterScript>().force /= slownessMultiplier;
      }
   }

   private void OnTriggerStay2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         gm.health -= damagePerSecond * Time.deltaTime;
      }
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         Player.GetComponent<Rigidbody2D>().velocity *= slownessMultiplier;
         Player.GetComponent<CopterScript>().force *= slownessMultiplier;
      }
   }

}
