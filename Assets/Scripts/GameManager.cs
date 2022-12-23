using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

      loadData();

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
         saveData();
      }

      if (player!=null && player.transform.position.y-playerStartPos > score && !hasDied)
      {
         score = player.transform.position.y-playerStartPos;
      }

      if (score > highScore)
      {
         highScore = score;
      }

      if (player != null)
      {
         transform.position = player.transform.position;
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

   void saveData()
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + Path.DirectorySeparatorChar + "theSaveData.fun";

      FileStream stream = new FileStream(path, FileMode.Create);

      formatter.Serialize(stream, highScore);
      stream.Close();

   }

   void loadData()
   {
      string path = Application.persistentDataPath + Path.DirectorySeparatorChar + "theSaveData.fun";

      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         highScore = (float)formatter.Deserialize(stream);
         stream.Close();
         return;
      }
      else
      {
         Debug.Log("Save File not found in "+path);
         return;
      }
   }

}
