using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool hasList = false;
    public bool hasLig_1 = false;
    public bool hasLig_2 = false;
    public bool hasLig_3 = false; 
    public bool all_lig_comp = false;


    [SerializeField] private GameObject List_UI;
    [SerializeField] private GameObject Work1_Arrow;
    public Text Component_Obj_UI;

    // Update is called once per frame
    void Update()
    {
        if (hasList){
            List_UI.SetActive(true);
        }

        if (hasLig_1 && hasLig_2 && hasLig_3){
            Component_Obj_UI.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
            Work1_Arrow.SetActive(true);
            all_lig_comp = true;
        }
    }
}
