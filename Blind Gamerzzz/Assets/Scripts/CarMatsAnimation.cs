using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMatsAnimation : MonoBehaviour, IInteractable
{
    public Animator animator;
    public ElectroMagnet magnet;
    public AnimationTracker tracker;
    public void AnimatePart(){
        magnet.RemoveElectroMagnet();
        animator.SetTrigger("Changes");
    }

    void IInteractable.Interact()
    {
        AnimatePart();
    }

    public void Tracking(){
        tracker.Animation1Played();
        Debug.Log("first anim");
    }
}
