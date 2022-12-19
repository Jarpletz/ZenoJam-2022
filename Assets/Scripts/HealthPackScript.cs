using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour
{
    GameManager gm;
    private Rigidbody2D rb;

    [SerializeField] private float healModifyer = 30;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gm.health > (gm.maxHealth - healModifyer))
            {
                gm.health = gm.maxHealth;
            }
            else
            {
                gm.health += healModifyer;
            }
            Destroy(gameObject);
        }
    }
}

