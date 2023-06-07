using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Variables are all serialized fields that can be tweaked in the Unity Inspector
    [SerializeField] public Transform cam;
    [SerializeField] public float range;
    [SerializeField] public KeyCode int_key = KeyCode.E;
    [SerializeField] public bool interactable_obj = false;

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the source position (the Camera) and shoot it out forward
        Ray r = new Ray(cam.position, cam.forward);
        // Performs a raycasts and check if it hits an object within its range
        if (Physics.Raycast(r, out RaycastHit hitInfo, range)) {

            // Check if the hit object has the IInteractable component (wont work on objects without the IIteractable component)

            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){

                interactable_obj = true;
                if (Input.GetKeyDown(int_key)){
                // Calls the Interact method on the object
                interactObj.Interact();
                }
                return;
            } 
        }

        interactable_obj = false;
        
    }

}

interface IInteractable{
    public void Interact();
}