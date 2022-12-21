using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI ScoreText;
   [SerializeField] TextMeshProUGUI FlareText;

   [SerializeField] Slider HealthSlider;


   GameManager gm;
   Animator animator;

   // Start is called before the first frame update
   void Start()
   {
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
      animator = GetComponent<Animator>();

      HealthSlider.maxValue = gm.maxHealth;

   }

   // Update is called once per frame
   void Update()
   {
      ScoreText.text = "Score: " + gm.score.ToString("0");
      FlareText.text = ": " + gm.flares.ToString("0");

      HealthSlider.value = gm.health;

      animator.SetBool("hasStarted", gm.hasStartedGame);
      animator.SetBool("hasDied", gm.hasDied);

   }
}
