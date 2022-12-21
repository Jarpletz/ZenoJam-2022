using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rockSpawnerScript : MonoBehaviour
{
    public GameObject rock;
    [SerializeField] Vector3 copterPoss;
    [SerializeField] Vector3 spawnerPoss;
    [SerializeField] float spawnRate = 2;
    [SerializeField] float startTorque;
    private float timer = 0;
    
    [SerializeField] private float offSet = 18;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
      gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
      if (!gm.hasStartedGame)
      {
         return;
      }

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
        //Debug.Log("Spawning Rock");
        float lowPoint = transform.position.x - offSet;
        float highPoint = transform.position.x + offSet;
        GameObject Rock =Instantiate(rock, new Vector3(Random.Range(lowPoint,highPoint),
            transform.position.y, transform.position.z), transform.rotation);
      Rock.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startTorque, startTorque), ForceMode2D.Impulse);
    }
}
