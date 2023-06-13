using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMatsAnimationLight : MonoBehaviour, IInteractable
{
    public Animator animator;
    public ElectroMagnet magnet;
    public AnimationTracker tracker;
    public void AnimatePart(){
        magnet.RemoveLightBulb();
        animator.SetTrigger("Changes");
    }

    void IInteractable.Interact()
    {

        AnimatePart();
    }

    public void Tracking(){
        tracker.Animation2Played();
        Debug.Log("sec anim");
    }
}
