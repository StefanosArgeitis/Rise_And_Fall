using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Comp3 : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public GameObject L_Comp_3;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        inv.hasLig_3 = true;
        L_Comp_3.gameObject.SetActive(false);
        return true;
    }
}