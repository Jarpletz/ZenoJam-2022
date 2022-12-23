using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimationController : MonoBehaviour
{
   // Start is called before the first frame update
   Animator animator;
   int timesClicked=0;


    void Start()
    {
      animator=GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonUp(0))
      {
         timesClicked++;
      }  
      animator.SetInteger("TimesClicked",timesClicked);

    }
}
