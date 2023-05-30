using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LightBulb : MonoBehaviour, IInteractable
{
    public Inventory inv;
    public GameObject minigame_UI;
    public TextMeshProUGUI no_comp;
    public float no_comp_time = 2f;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        if (inv.all_lig_comp){

            minigame_UI.SetActive(true);
            return true;
        
        } else{
            Debug.Log ("table22");
            no_comp.enabled = true;
            StartCoroutine("no_comps");
        }
        Debug.Log ("table");
        return false;
        
    }

    public IEnumerator no_comps(){

        yield return new WaitForSeconds(no_comp_time);

        no_comp.enabled = false;

    }
}
