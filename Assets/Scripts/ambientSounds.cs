using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambientSounds : MonoBehaviour
{

    [SerializeField] AudioSource source;
    [SerializeField]float maxVolume=1;
    [SerializeField] Vector2 soundRange=new Vector2(1,6);
    Transform Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, Player.position);

        if (dist < soundRange.x)
        {
            source.volume = 1;
        }
        else if (dist > soundRange.y)
        {
            source.volume = 0;
        }
        else
        {
            source.volume = Mathf.Lerp(0, 1, 1-(dist / soundRange.y));
        }
        source.volume = Mathf.Clamp(source.volume, 0, maxVolume);
    }
}
