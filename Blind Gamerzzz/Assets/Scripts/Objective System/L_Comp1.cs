using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Comp1 : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public GameObject L_Comp_1;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        inv.hasLig_1 = true;
        L_Comp_1.gameObject.SetActive(false);
        return true;
    }
}
