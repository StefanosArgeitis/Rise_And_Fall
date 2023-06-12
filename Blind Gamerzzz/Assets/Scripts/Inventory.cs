using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool hasList = false;
    public bool all_lig_comp = false;


    [SerializeField] private GameObject List_UI;
    [SerializeField] private GameObject firstMini;
    [SerializeField] private GameObject secondMini;
    public Text Component_Obj_UI;
    public Text Component_Obj_UI2;
    public Text Component_Obj_UI3;
    public LightBulb bulb;
    public bool first_task = false;

    // Update is called once per frame
    void Update()
    {
        if (!first_task){
            ObjectivesLightBulb();
        }

        
    }

    void ObjectivesLightBulb(){

        if (bulb.secondBulb){
            Component_Obj_UI3.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
            Invoke(nameof(firsObjectives), 5);
        }

        if (hasList){
            List_UI.SetActive(true);
        }

        if (!bulb.firstBulb){
            Component_Obj_UI2.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
        }

        if (bulb.allMatsCollected){
            Component_Obj_UI.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
            //Work1_Arrow.SetActive(true);
            all_lig_comp = true;
        }
    }

    void firsObjectives(){
        Component_Obj_UI.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        Component_Obj_UI2.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        Component_Obj_UI3.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        first_task = true;
        
        firstMini.SetActive(false);
        secondMini.SetActive(true);

    }


}
