using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] KeyCode startKey;

   [SerializeField] GameObject player;
   float playerStartPos;

   public float maxHealth;
   public float health;

   public float flares;
   public float startingFlares;

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
         //managers[0].GetComponent<GameManager>().resetGM();
         Destroy(this.gameObject);
      }
      DontDestroyOnLoad(this.gameObject);
      //Adds Dont Destroy on Load

      player = GameObject.FindWithTag("Player");
      if(player!=null) playerStartPos = player.transform.position.y;
      flares = startingFlares;
   }

   // Update is called once per frame
   void Update()
   {
      player = GameObject.FindWithTag("Player");

      if (!hasStartedGame && Input.GetKeyDown(startKey))
      {
         hasStartedGame= true;
      }

      if (health <= 0)
      {
         hasDied = true;
      }

      if (player!=null && player.transform.position.y-playerStartPos > score && !hasDied)
      {
         score = player.transform.position.y-playerStartPos;
      }

      if (score > highScore)
      {
         highScore = score;
      }

   }
   public void resetGM()
   {
      health = maxHealth;
      score = 0;
      flares = startingFlares;
      hasDied = false;
      hasStartedGame = false;
   }

   
}
