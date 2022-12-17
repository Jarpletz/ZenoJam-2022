using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCopter : MonoBehaviour
{
    public GameObject copter;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(copter, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
