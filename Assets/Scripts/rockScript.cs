using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Vector3 copterPoss;
    [SerializeField] private float deadZone = -50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        copterPoss = GameObject.FindWithTag("Player").transform.position;
        transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;
        if (transform.position.y < copterPoss.y - 50)
        {
            Destroy(gameObject);
        }
    }
}

