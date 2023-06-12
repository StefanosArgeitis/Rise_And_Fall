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
    public Text Component_Obj_UI4;
    public Text Component_Obj_UI5;
    public Text Component_Obj_UI6;
    public LightBulb bulb;
    public ElectroMagnet magnet;
    public GameObject car_Light;
    public GameObject car_Light1;
    public GameObject car_magnet;
    public bool first_task = false;
    public bool second_task = false;
    public bool final_task = false;
    public bool no_more_task = false;

    // Update is called once per frame
    void Update()
    {
        if (no_more_task){
            return;
        }

        if (final_task){
            Invoke(nameof(finalObjective), 3);
            no_more_task = true;
            return;
        }

        if (first_task){
            ObjectivesElectro();
        } else{
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

    void ObjectivesElectro(){
        if (magnet.allMatsCollected){
            Component_Obj_UI4.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
            Debug.Log("WORKS");
        }

        if (magnet.electroMagnet){
            Component_Obj_UI5.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0.3f);
            Invoke(nameof(secondObjective), 5);
        }
    }

    void ObjectivesElectroOn(){
        if (!second_task){
        Component_Obj_UI4.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 1f);
        Component_Obj_UI5.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 1f);
        second_task = true;
        }  
    }

    void firsObjectives(){
        Component_Obj_UI.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        Component_Obj_UI2.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        Component_Obj_UI3.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        first_task = true;

        firstMini.SetActive(false);
        secondMini.SetActive(true);
        Invoke(nameof(ObjectivesElectroOn), 2);
    }

    void secondObjective(){
        Component_Obj_UI4.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        Component_Obj_UI5.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 0f);
        final_task = true;
    }

    void finalObjective(){
        Component_Obj_UI6.color = new Color (Component_Obj_UI.color.r, Component_Obj_UI.color.g, Component_Obj_UI.color.b, 1f);
        car_Light.SetActive(true);
        car_Light1.SetActive(true);
        car_magnet.SetActive(true);
    }


}
