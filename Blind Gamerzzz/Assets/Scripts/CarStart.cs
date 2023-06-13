using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStart : MonoBehaviour, IInteractable
{
    public Narrator nar;
    public void Interact()
    {
        nar.GetJournal();
    }

}
