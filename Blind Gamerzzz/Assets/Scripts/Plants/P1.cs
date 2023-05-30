using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour //IInteractable
{/*
    public Material[] materials;
    [SerializeField] private GameObject poison_n_UI;
    public float deathTime = 5f;
    public float poisonTime = 2f;
    public Inventory inv;
    Renderer rendr;
    public string interactionPrompt => throw new System.NotImplementedException();

    public bool Interact(Interactor interactor)
    {
        if(inv.hasPoison){

            StartCoroutine("deathTimer");
            return true;

        } else{

            poison_n_UI.SetActive(true);
            StartCoroutine("poisonTimer");

        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rendr = GetComponent<Renderer>();
        rendr.enabled = true; 
        rendr.sharedMaterial = materials[0];
    }

    public IEnumerator deathTimer(){

        yield return new WaitForSeconds(deathTime);

        rendr.sharedMaterial = materials[1];

    }

    public IEnumerator poisonTimer(){

        yield return new WaitForSeconds(poisonTime);

        poison_n_UI.SetActive(false);

    }
    */
}
