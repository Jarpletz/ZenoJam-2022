using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
   [SerializeField] float spaceBetweenLevels;
   [SerializeField] GameObject[] Levels;
   [SerializeField] List<GameObject> ActiveLevels= new List<GameObject>();
   

   Transform PlayerPos;
   GameObject TopLevel;

   private void Start()
   {
      PlayerPos = GameObject.FindWithTag("Player").transform;
   }

   private void Update()
   {
      TopLevel = ActiveLevels[ActiveLevels.Count - 1];//Find the Top Level

      if (PlayerPos.position.y > TopLevel.transform.position.y + (spaceBetweenLevels / 2)){
         GameObject newLevel;
         newLevel = Instantiate(getRandomLevel());
         newLevel.transform.position =new  Vector3(0, TopLevel.transform.position.y + spaceBetweenLevels, 0);
         ActiveLevels.Add(newLevel);
      }//If close enough to the top, Create a new level

      if (ActiveLevels[0].transform.position.y< PlayerPos.position.y- (spaceBetweenLevels*2f))
      {
         Destroy(ActiveLevels[0]);
         ActiveLevels.RemoveAt(0);
      }

   }

   GameObject getRandomLevel()
   {
      GameObject level;
      int rand = Random.Range(0, Levels.Length);
      level = Levels[rand];
      return level;
   }


}
