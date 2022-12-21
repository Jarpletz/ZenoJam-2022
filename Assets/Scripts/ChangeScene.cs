using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
      Debug.Log("Loading Scene" + sceneIndex);

      SceneManager.LoadScene(sceneIndex);
    }

   public void ResetGM()
   {
      GameManager gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
      gm.health = gm.maxHealth;
      gm.score = 0;
      gm.flares = gm.startingFlares;
      gm.hasDied = false;
      gm.hasStartedGame = false;
      
   }

}

