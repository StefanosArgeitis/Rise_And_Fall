using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Comp2 : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public GameObject L_Comp_2;
    public string interactionPrompt => throw new System.NotImplementedException();

    void IInteractable.Interact()
    {
        inv.hasLig_2 = true;
        L_Comp_2.gameObject.SetActive(false);
    }
}
