using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBulb : MonoBehaviour, IInteractable
{
    string IInteractable.interactionPrompt => throw new System.NotImplementedException();

    public static event HandleBulbCollected OnBulbCollected;
    public delegate void HandleBulbCollected(ItemData itemData);
    public ItemData bulbData; 

    public bool Interact(Interactor interactor)
    {
        Destroy(gameObject);
        OnBulbCollected?.Invoke(bulbData);
        return true;
    }

}
