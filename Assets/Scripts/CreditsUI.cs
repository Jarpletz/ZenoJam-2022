using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void returnToStartScreen()
   {
      animator.SetBool("Return", true);
   }
}
