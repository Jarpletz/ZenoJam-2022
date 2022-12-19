using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   GameObject player;

   public float maxHealth;
   public float health;

   public float flares;

   public float score;
   public float highScore;


   // Start is called before the first frame update
   void Awake()
   {
      GameObject[] managers = GameObject.FindGameObjectsWithTag("GameManager");
      if (managers.Length > 1)
      {
         Destroy(this.gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
      //Adds Dont Destroy on Load

      player = GameObject.FindWithTag("Player");
   }

   // Update is called once per frame
   void Update()
   {
      if (player.transform.position.y > score)
      {
         score = player.transform.position.y;
      }
   }
}
