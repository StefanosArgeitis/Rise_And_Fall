using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroMagnet : MonoBehaviour, IInteractable
{
    public GameObject minigame_UI;
    public GameObject no_comp;
    public float no_comp_time = 2f;
    public bool electroMagnet = false;

    public static event HandleTestCollected OnRemoved;
    public delegate void HandleTestCollected(ItemData itemData);
    public ItemData itemData;
    public ItemData itemData2;
    public ItemData itemData3;
    public ItemData itemData4;
    public bool allMatsCollected = false;
    public bool allMatsPlaced = false;
    public SwitchCamera switchCamera;
    public Inventory inv;
    public ElectroMini mini;
    public InventoryChecker invCheck;

    void IInteractable.Interact()
    {
        invCheck.CheckInventory();

       if (electroMagnet){
            return;
        }

        if (allMatsPlaced){
            switchCamera.ChangeCam();
            Invoke(nameof(StartMini), 3);
            return;
        }


        if (allMatsCollected){

            OnRemoved?.Invoke(itemData);
            OnRemoved?.Invoke(itemData2);
            mini.lightbulb_comps.SetActive(true);
            allMatsPlaced = true;
            return;
        
        }

        noComps();

        return;
    }

    public void RemoveElectroMagnet(){
        OnRemoved?.Invoke(itemData3);
    }
    public void RemoveLightBulb(){
        OnRemoved?.Invoke(itemData4);
    }


    public IEnumerator no_comps(){

        yield return new WaitForSeconds(no_comp_time);

        no_comp.SetActive(false);

    }
    
    public void noComps(){
        no_comp.SetActive(true);
        StartCoroutine("no_comps");
    }

    public void StartMini(){
        minigame_UI.SetActive(true);
    }
}