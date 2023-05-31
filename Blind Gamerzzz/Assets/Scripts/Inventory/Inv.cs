using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inv : MonoBehaviour
{
   public List<InvItem> inventory = new List<InvItem>();
   public static event Action<List<InvItem>> OnInventoryChange;
   private Dictionary<ItemData, InvItem> itemDictionary = new Dictionary<ItemData, InvItem>();

   private void OnEnable() {
        ItemsBulb.OnBulbCollected += Add;
   }

   private void OnDisable() {
        ItemsBulb.OnBulbCollected -= Add;
   }

   public void Add(ItemData itemData){

    if (itemDictionary.TryGetValue(itemData, out InvItem item)){

        item.AddStack();
        Debug.Log($"{item.itemData.displayName} total stack is now {item.stack_size}");
        OnInventoryChange?.Invoke(inventory);

    } else{

        InvItem newItem = new InvItem(itemData);
        inventory.Add(newItem);
        itemDictionary.Add(itemData, newItem);
        Debug.Log($"Added {itemData.displayName} to the inventory for the first time.");
        OnInventoryChange?.Invoke(inventory);
    }

   }

    public void Remove(ItemData itemData){

        if (itemDictionary.TryGetValue(itemData, out InvItem item)){

            item.RemoveStack();
            if (item.stack_size == 0){
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }
}
