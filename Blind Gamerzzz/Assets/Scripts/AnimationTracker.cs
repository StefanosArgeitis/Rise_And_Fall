using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTracker : MonoBehaviour
{
    [SerializeField] public bool animation1Played = false;
    [SerializeField] public bool animation2Played = false;
    [SerializeField] public bool animation3Played = false;
    public Narrator nar;
    public FlaxWheel flax;

    public void Animation1Played(){
        animation1Played = true;
        CheckAllAnimationsPlayed();
    }

   
    public void Animation2Played(){
        animation2Played = true;
        CheckAllAnimationsPlayed();
    }

   
    public void Animation3Played(){
        animation3Played = true;
        CheckAllAnimationsPlayed();
    }

    private void CheckAllAnimationsPlayed(){
        if (animation1Played && animation2Played && animation3Played)
        {
            Invoke(nameof(endingAudio), 1);
        }
    }

    void endingAudio(){
        nar.PlayEnd();
        Invoke(nameof(ending), 13);
    }

    void ending(){
        flax.p_Transfer();
    }
}
