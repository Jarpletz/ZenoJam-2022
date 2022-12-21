using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] KeyCode startKey;

   GameObject player;
   float playerStartPos;

   public float maxHealth;
   public float health;

   public float flares;

   public float score;
   public float highScore;

   public bool hasStartedGame=false;
   public bool hasDied=false;


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
      playerStartPos = player.transform.position.y;
   }

   // Update is called once per frame
   void Update()
   {
      if(!hasStartedGame && Input.GetKeyDown(startKey))
      {
         hasStartedGame= true;
      }

      if (health <= 0)
      {
         hasDied = true;
      }

      if (player.transform.position.y-playerStartPos > score && !hasDied)
      {
         score = player.transform.position.y-playerStartPos;
      }
   }
}
