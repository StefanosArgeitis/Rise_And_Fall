using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public Narrator nar;
    public GameObject o_list;
    public GameObject carStart;
    //public GameObject test;
    public string interactionPrompt => throw new System.NotImplementedException();

    void IInteractable.Interact()
    {
        inv.hasList = true;
        nar.PlayJournal();
        o_list.gameObject.SetActive(false);
        carStart.SetActive(false);
        //test.SetActive(true);
    }
}
