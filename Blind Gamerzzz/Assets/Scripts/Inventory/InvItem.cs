using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InvItem
{
    public ItemData itemData;
    public int stack_size;

    public InvItem(ItemData item){
        itemData = item;
        AddStack();
    }

    public void AddStack(){
        stack_size++;
    }

    public void RemoveStack(){
        stack_size--;
    }

}
