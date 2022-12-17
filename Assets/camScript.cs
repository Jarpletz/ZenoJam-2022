using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 copterPoss;
    [SerializeField] Vector3 camPoss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        copterPoss = GameObject.FindWithTag("Player").transform.position;
        camPoss = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(camPoss.x, copterPoss.y, camPoss.z);

    }
}
