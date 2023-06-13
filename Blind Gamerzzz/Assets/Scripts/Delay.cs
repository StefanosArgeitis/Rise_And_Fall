using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
        Invoke("playAudio", 2f);
    }

    void playAudio(){
        music.Play();
    }

}