using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public GameObject o_list;
    //public GameObject test;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        inv.hasList = true;
        o_list.gameObject.SetActive(false);
        //test.SetActive(true);
        return true;
    }
}
