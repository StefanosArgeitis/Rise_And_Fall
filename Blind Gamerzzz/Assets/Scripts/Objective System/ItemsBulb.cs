using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBulb : MonoBehaviour, IInteractable
{

    public static event HandleBulbCollected OnBulbCollected;
    public delegate void HandleBulbCollected(ItemData itemData);
    public ItemData bulbData; 
    public InventoryChecker invCheck;

    void IInteractable.Interact()
    {
        Destroy(gameObject);
        OnBulbCollected?.Invoke(bulbData);
        invCheck.CheckInventory();
    }
}
