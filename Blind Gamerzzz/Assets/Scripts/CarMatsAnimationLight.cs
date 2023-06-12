using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMatsAnimationLight : MonoBehaviour, IInteractable
{
    public Animator animator;
    public ElectroMagnet magnet;
    public void AnimatePart(){
        magnet.RemoveLightBulb();
        animator.SetTrigger("Changes");
    }

    void IInteractable.Interact()
    {
        
        AnimatePart();
    }
}
