using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    
    [SerializeField] public GameObject cam1;
    [SerializeField] public GameObject cam2;
    public int Manager;

    public void ChangeCam(){
        GetComponent<Animator>().SetTrigger("Change");
    }

    public void ManageCam(){

        if (Manager == 0){
            Cam_1();
            Manager = 1;
        } else{
            Cam_2();
            Manager = 0;
        }
    }

    void Cam_1(){
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void Cam_2(){
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
