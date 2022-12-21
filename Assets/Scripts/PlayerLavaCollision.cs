using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLavaCollision : MonoBehaviour
{
   GameManager gm;
   GameObject Player;

   [SerializeField] float damagePerSecond;
   [SerializeField] float slownessMultiplier;

   private void Start()
   {
      Player = GameObject.FindWithTag("Player");
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
