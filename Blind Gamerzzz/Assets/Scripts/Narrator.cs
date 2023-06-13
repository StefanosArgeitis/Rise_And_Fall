using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public AudioSource source;
    public AudioClip introClip;
    public AudioClip GetBookClip;
    public AudioClip JournalClip;
    public AudioClip LightBulbCompsClip;
    public AudioClip LightBulbAllCompsClip;
    public AudioClip ElectroMagClip;
    public AudioClip ElectroMagCompsClip;
    public AudioClip ElectroMagDoneClip;
    public AudioClip EndClip;

    void Start()
    {
        Invoke("PlayAudio", 2f);
    }

    void PlayAudio()
    {
        StopAudio(); 
        source.PlayOneShot(introClip);
    }

    public void PlayJournal()
    {
        StopAudio(); 
        source.PlayOneShot(JournalClip);
    }

    public void GetJournal(){
        StopAudio(); 
        source.PlayOneShot(GetBookClip);
    }

    public void PlayLightComps(){
    Invoke(nameof(LightComps), 5);
    }

    void LightComps(){
        StopAudio();
        source.PlayOneShot(LightBulbCompsClip);
    }

    public void PlayAllLightComps(){
        StopAudio();
        source.PlayOneShot(LightBulbAllCompsClip);
    }

    public void PlayElectroMag(){
    Invoke(nameof(ElectroMag), 5);
    }

    void ElectroMag(){
        StopAudio();
        source.PlayOneShot(ElectroMagClip);
    }

    public void PlayAllMagComps(){
        StopAudio();
        source.PlayOneShot(ElectroMagCompsClip);
    }

    public void PlayMagDone(){
        Invoke(nameof(PlayMagnetDone), 5);
    }
    void PlayMagnetDone(){
        StopAudio();
        source.PlayOneShot(ElectroMagDoneClip);
    }

    public void PlayEnd(){
        StopAudio();
        source.PlayOneShot(EndClip);
    }


    void StopAudio()
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
}