using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private GameObject E_press_UI;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask Interact_Mask;
    [SerializeField] private int numFound;
    [SerializeField] public KeyCode int_key = KeyCode.E;

    // Will stop searching after 3 objects
    private readonly Collider[] _colliders = new Collider[3];

    private void Update() {

        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, _colliders, Interact_Mask);


        if (numFound > 0){

            E_press_UI.SetActive(true);

            var interactable = _colliders[0].GetComponent<IInteractable>();

            if (interactable != null && Input.GetKeyDown(int_key)){
                interactable.Interact(this);
            }
            
        } else{
            E_press_UI.SetActive(false);
        }
    }

    private void OnDrawGizmos(){
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);

    }
}
