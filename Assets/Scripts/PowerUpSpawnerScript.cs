using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject flare;
    public GameObject healthPack;
    private GameObject powerUp;
    [SerializeField] Vector3 copterPoss;
    [SerializeField] Vector3 spawnerPoss;
    [SerializeField] float spawnRate = 10;
    [SerializeField] float startTorque;
    private float timer = 0;
    
    [SerializeField] private float offSet = 18;
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
            spawnPowerUp();
            timer = 0;
        }
    }

    void spawnPowerUp()
    {
        int random = Random.Range(0, 2);
        if (random != 1)
        {
            powerUp = flare;
        }
        else
        {
            powerUp = healthPack;
        }
        float lowPoint = transform.position.x - offSet;
        float highPoint = transform.position.x + offSet;
        GameObject PowerUp =Instantiate(powerUp, new Vector3(Random.Range(lowPoint,highPoint),
            transform.position.y, transform.position.z), transform.rotation);
        PowerUp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-startTorque, startTorque), ForceMode2D.Impulse);
    }
}
