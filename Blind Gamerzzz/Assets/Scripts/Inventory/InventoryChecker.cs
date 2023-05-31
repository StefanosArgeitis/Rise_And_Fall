using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChecker : MonoBehaviour
{
    public Inv inventoryScript; // Reference to the Inv script
    public LightBulb comps;

    public void CheckInventory()
    {
        string[] targetStrings = { "Wire", "Bulb", "Cap" };
        bool containsAllStrings = true;

        foreach (string targetString in targetStrings)
        {
            bool containsString = false;
            
            foreach (InvItem item in inventoryScript.inventory)
            {
                if (item.itemData.displayName == targetString)
                {
                    containsString = true;
                    break;
                }
            }
            
            if (!containsString)
            {
                containsAllStrings = false;
                break;
            }
        }

        if (containsAllStrings){
            Debug.Log("The inventory contains all target strings.");
            comps.allMatsCollected = true;

        }
        else{
            Debug.Log("The inventory does not contain all target strings.");
        }
    }
}
