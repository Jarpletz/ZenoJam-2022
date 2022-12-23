using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource source;
    [SerializeField] bool scaleSoundByDistance=true;
    [SerializeField] Vector2 soundRange=new Vector2(1f,9f);
    [SerializeField] float maxVolume = 1;
    [Header("If no AudioSource Component, uses one in gameManager")]
    [SerializeField] float volume=1;

    Transform player;
    [System.Serializable] public class soundEffect
    {
        public AudioClip[] clips;
        public string soundName;
        public bool noOverlap;//Can it play over another instance of itself? true for no.
        public float overlapTime;//if true, the amount of time until it can play again
        //[HideInInspector]
        public float timer=0;//time till can repeat again 
    }
    public soundEffect[] soundEffects;

    private void Start()
    {
        if (GetComponent<AudioSource>() == null)
        {
            source = GameObject.FindWithTag("GameManager").GetComponent<AudioSource>();
        }
        else  source = GetComponent<AudioSource>();
        if (GameObject.FindWithTag("Player"))
        {


           player = GameObject.FindWithTag("Player").transform;
        }

    }
    private void Update()
    {
        foreach(soundEffect s in soundEffects)
        {
            if (s.noOverlap&&s.timer>0)
            {
                s.timer -= Time.deltaTime;
            }
        }
        if (scaleSoundByDistance)
        {
            float dist = Vector3.Distance(transform.position, player.position);

            if (dist < soundRange.x)
            {
                volume = 1;
            }
            else if (dist > soundRange.y)
            {
                volume = 0;
            }
            else
            {
                volume = Mathf.Lerp(0, 1, 1 - (dist / soundRange.y));
            }
            volume = Mathf.Clamp(volume, 0, maxVolume);

        }
        source.volume=volume;
       
    }
    public void playSound(string soundName, float volumeMult = 1f)
    {
        foreach(soundEffect s in soundEffects)
        {
            if (soundName == s.soundName)
            {
                if (s.timer <= 0)
                {
                    source.PlayOneShot(s.clips[Random.Range(0, s.clips.Length)],volume*volumeMult);
                    if (s.noOverlap) s.timer = s.overlapTime;
                }
                return;
            }
        }

        Debug.LogError("Sound of name '" + soundName + "' not found!");
    }
    public void playSoundAnimation(string soundName)
    {
        foreach (soundEffect s in soundEffects)
        {
            if (soundName == s.soundName)
            {
                if (s.timer <= 0)
                {
                    source.PlayOneShot(s.clips[Random.Range(0, s.clips.Length)]);
                    if (s.noOverlap) s.timer = s.overlapTime;
                }
                return;
            }
        }

        Debug.LogError("Sound of name '" + soundName + "' not found for "+gameObject.name+"!");
    }
    public soundEffect returnSound(string soundName)
    {
        foreach(soundEffect s in soundEffects)
        {
            if (s.soundName == soundName) return s;
        }
        Debug.LogWarning("Sound of name '" + soundName + "' not found for " + gameObject.name + "!");
        return null;
    }
}
