using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv : MonoBehaviour
{
   public List<InvItem> inventory = new List<InvItem>();
   private Dictionary<ItemData, InvItem> itemDictionary = new Dictionary<ItemData, InvItem>();

   public void Add(ItemData itemData){

    if (itemDictionary.TryGetValue(itemData, out InvItem item)){

        item.AddStack();

    } else{

        InvItem newItem = new InvItem(itemData);
        inventory.Add(newItem);
        itemDictionary.Add(itemData, newItem);
    }

   }

    public void Remove(ItemData itemData){

        if (itemDictionary.TryGetValue(itemData, out InvItem item)){

            item.RemoveStack();
            if (item.stack_size == 0){
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }
}
