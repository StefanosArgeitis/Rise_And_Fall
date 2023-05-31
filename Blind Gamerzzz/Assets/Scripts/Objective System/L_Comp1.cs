using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Comp1 : MonoBehaviour, IInteractable
{
    public static event HandleTestCollected OnRemoved;
    public delegate void HandleTestCollected(ItemData itemData);
    public ItemData itemData;
    public ItemData itemData2;
    public ItemData itemData3;
    public bool allMatsCollected = false;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        if (allMatsCollected){

        OnRemoved?.Invoke(itemData);
        OnRemoved?.Invoke(itemData2);
        OnRemoved?.Invoke(itemData3);
        
        return true;

        }

        return false;
    }

}
