using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockSpawnerScript : MonoBehaviour
{
    public GameObject rock;
    [SerializeField] Vector3 copterPoss;
    [SerializeField] Vector3 spawnerPoss;
    [SerializeField] float spawnRate = 2;
    private float timer = 0;
    
    [SerializeField] private float offSet = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        copterPoss = GameObject.FindWithTag("Player").transform.position;
        spawnerPoss = transform.position;
        transform.position = new Vector3(spawnerPoss.x, copterPoss.y+10, spawnerPoss.z);
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnRock();
            timer = 0;
        }
    }

    void spawnRock()
    {
        float lowPoint = transform.position.x - offSet;
        float highPoint = transform.position.x + offSet;
        Instantiate(rock, new Vector3(Random.Range(lowPoint,highPoint),
            transform.position.y, transform.position.z), transform.rotation);
    }
}
