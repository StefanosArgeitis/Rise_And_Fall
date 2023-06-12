using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMatsAnimation : MonoBehaviour, IInteractable
{
    public Animator animator;
    public ElectroMagnet magnet;
    public void AnimatePart(){
        magnet.RemoveElectroMagnet();
        animator.SetTrigger("Changes");
    }

    void IInteractable.Interact()
    {
        AnimatePart();
    }
}
