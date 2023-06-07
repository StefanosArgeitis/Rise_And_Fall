using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [SerializeField] private GameObject E_press_UI;
    [SerializeField] public LightBulbMini Mini_game;
    public Interactable inter;

    private void Update() {

        if (Mini_game.pause_char){
            E_press_UI.SetActive(false);
            return;
        }

        if (inter.interactable_obj){
            E_press_UI.SetActive(true);
        }else{
            E_press_UI.SetActive(false);
        }

        
    }

}
