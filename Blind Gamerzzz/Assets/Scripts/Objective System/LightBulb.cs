using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LightBulb : MonoBehaviour, IInteractable
{
    public GameObject minigame_UI;
    public GameObject no_comp;
    public float no_comp_time = 2f;
    public bool firstBulb = true;
    public bool secondBulb = false;

    public static event HandleTestCollected OnRemoved;
    public delegate void HandleTestCollected(ItemData itemData);
    public ItemData itemData;
    public ItemData itemData2;
    public ItemData itemData3;
    public bool allMatsCollected = false;
    public bool allMatsPlaced = false;

    void IInteractable.Interact()
    {
       if (secondBulb){
            return;
        }

        if (allMatsPlaced){
            minigame_UI.SetActive(true);
            return;
        }
        
        if (firstBulb){
           
            minigame_UI.SetActive(true);
            return;
        }


        if (allMatsCollected){

            OnRemoved?.Invoke(itemData);
            OnRemoved?.Invoke(itemData2);
            OnRemoved?.Invoke(itemData3);
            
            allMatsPlaced = true;
            return;
        
        }

        noComps();

        return;
    }

    public IEnumerator no_comps(){

        yield return new WaitForSeconds(no_comp_time);

        no_comp.SetActive(false);

    }
    
    public void noComps(){
        no_comp.SetActive(true);
        StartCoroutine("no_comps");
    }
}
