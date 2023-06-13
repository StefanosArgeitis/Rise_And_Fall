using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioDelay : MonoBehaviour
{
    public AudioSource music;
    public GameObject txt;
    public GameObject txt1;
    [SerializeField] private string loadLevel;
    void Start()
    {
        music = GetComponent<AudioSource>();
        Invoke("playAudio", 2f);
        Invoke("secondTxt", 8f);
        Invoke("next", 17f);
    }

    void playAudio(){
        txt.SetActive(true);
        music.Play();
    }

    void secondTxt(){
        txt.SetActive(false);
        txt1.SetActive(true);
    }

    void next(){
        SceneManager.LoadScene(loadLevel);
    }
}