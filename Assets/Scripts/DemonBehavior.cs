using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBehavior : MonoBehaviour
{

   [SerializeField] Transform head;
   [SerializeField] ParticleSystem flamePS;
   [SerializeField] float lookLerpSpeed;
   [Header("Attacking")]
   [SerializeField] float attackRange;
   [SerializeField] float attackCooldown;
   [SerializeField] float damagePerSecond;
   [SerializeField] LayerMask raycastLayers;
   [Header ("Bools")]
   [SerializeField] bool lockHeadMovement;
   [SerializeField] bool canAttack;
   [SerializeField] bool isAttacking;

   float cooldownLeft;

   Transform PlayerPos;
   GameManager gm;

   Animator animator;
   EnemyHealth health;

   Vector3 DirToPlayer;
   Vector3 directionScale;
   


   // Start is called before the first frame update
   void Start()
   {
      PlayerPos = GameObject.FindWithTag("Player").transform;
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
      animator = GetComponent<Animator>();
      health = GetComponent<EnemyHealth>();
   }

   // Update is called once per frame
   void LateUpdate()
   {
      if(!lockHeadMovement)DirToPlayer = PlayerPos.position - head.position;

      if(DirToPlayer.x > 0  &&transform.localScale.x<0 ||
         DirToPlayer.x < 0 && transform.localScale.x > 0)
      {
         directionScale.Set(-transform.localScale.x, transform.localScale.y, 1);
         transform.localScale = directionScale;
      }// Set the scale to make the demon face the player on the x-axis


      if (transform.localScale.x < 1)
      {
         head.right =Vector3.Lerp(head.right,-DirToPlayer,lookLerpSpeed);
      }
      else head.right = Vector3.Lerp(head.right, DirToPlayer, lookLerpSpeed);

      //Make the head look at the player

      if (cooldownLeft > 0)
      {
         cooldownLeft -= Time.deltaTime;
      }//Decrease the cooldown

      animator.SetBool("canAttack", canAttack);

      if (!health.isAlive)
      {
         animator.SetBool("isAlive", false);
         GetComponent<SoundManager>().playSound("DemonDeath", 1.6f);
         Destroy(gameObject, 1.5f);
      }
   }

   private void FixedUpdate()
   {
      RaycastHit2D hit = Physics2D.Raycast(head.position, DirToPlayer,attackRange,raycastLayers);


      if (hit.collider != null)
      {
         Debug.DrawLine(head.position, hit.point);
         if (hit.collider.gameObject.CompareTag("Player"))
         {

            if (cooldownLeft <= 0)
            {
               canAttack = true;
            }
            if (isAttacking)
            {
               gm.health -= damagePerSecond * Time.deltaTime;

            }
         }
      }

   }

   public void prepareAttack()
   {
      lockHeadMovement = true;
   }

   public void Attack()
   {
      isAttacking= true;
      flamePS.Play();
   }

   public void endAttack()
   {
      isAttacking = false;
      flamePS.Stop();
      canAttack = false;
      cooldownLeft = attackCooldown;
   }

   public void unlockHead()
   {
      lockHeadMovement = false;

   }
}


