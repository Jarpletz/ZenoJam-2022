using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

   [SerializeField] AudioClip[] songs;
   [SerializeField] float menuVolume;
   [SerializeField] float playVolume;
   [SerializeField] float fadeSpeed;

   GameManager gameManager;
   AudioSource sound;

   void Start()
   {
      gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
      sound= GetComponent<AudioSource>();

      sound.clip= songs[Random.Range(0, songs.Length)];
      sound.volume=menuVolume;
      sound.Play();

   }

   // Update is called once per frame
   void Update()
   {
      if(gameManager.hasStartedGame)
      {
         if (gameManager.hasDied)
         {
            sound.volume = Mathf.Lerp(sound.volume, 0, fadeSpeed * Time.deltaTime);
         }
         else
         {
            sound.volume = playVolume;
         }

      }
   }
}
