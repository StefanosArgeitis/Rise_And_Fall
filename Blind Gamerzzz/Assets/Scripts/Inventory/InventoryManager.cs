using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(5);

    private void OnEnable() {
        Inv.OnInventoryChange += DrawInventory;
    }

    private void OnDisable() {
        Inv.OnInventoryChange -= DrawInventory;
    }

    void ResetInventory(){

        foreach(Transform childTransform in transform){
            Destroy(childTransform.gameObject);
        }

        inventorySlots = new List<InventorySlot>(5);
    }

    void DrawInventory(List<InvItem> inventory){
        ResetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++){
            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++){
            inventorySlots[i].DrawSlot(inventory[i]);
        }
    }

    void CreateInventorySlot(){
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();
        inventorySlots.Add(newSlotComponent);
    }
}
