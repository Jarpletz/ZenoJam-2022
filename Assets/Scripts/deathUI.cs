using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class deathUI : MonoBehaviour
{
   [SerializeField] float percentOfScoreShown;
   [SerializeField] string[] deathMessages;
   float scoreShown;
   string deathMessage;

   [SerializeField] TextMeshProUGUI scoreText;
   [SerializeField] TextMeshProUGUI hsText;
   [SerializeField] TextMeshProUGUI titleText;

   [SerializeField] GameObject newHSText;

   GameManager gm;
   void Start()
   {
      gm=GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

      deathMessage = deathMessages[Random.Range(0, deathMessages.Length)];
      titleText.text = deathMessage;

      if (gm.score >= gm.highScore)
      {
         newHSText.SetActive(true);
      }
      else newHSText.SetActive(false);

   }

   // Update is called once per frame
   void Update()
   {

      hsText.text ="Highscore: " +gm.highScore.ToString("0");

      scoreShown = gm.score * percentOfScoreShown;
      scoreText.text = "You got\n" + scoreShown.ToString("0") + " Meters\nCloser to the Roof of Hell";

   }
   public void playRestartAnimation()
   {
      GetComponent<Animator>().SetBool("Restart", true);
   }

   public void playNewHsSound()
   {
      if (gm.score >= gm.highScore)
      {
         GetComponent<SoundManager>().playSound("NewHighscore");
      }
   }

}
