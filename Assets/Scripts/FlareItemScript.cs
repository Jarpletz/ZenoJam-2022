using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareItemScript : MonoBehaviour
{
    GameManager gm;
    private Rigidbody2D rb;

    [SerializeField] private float flareModifyer = 1;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.flares += flareModifyer;
            Destroy(gameObject);
        }
    }
}
