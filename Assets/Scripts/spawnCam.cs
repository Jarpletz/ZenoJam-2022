using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCam : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cam, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
