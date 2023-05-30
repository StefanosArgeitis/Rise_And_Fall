using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbMini : MonoBehaviour
{
    [SerializeField] private Transform top_Pivot;
    [SerializeField] private Transform bottom_Pivot;
    [SerializeField] private Transform mini_objective;
   
    public float mini_obj_pos;
    public float mini_obj_des;

    public float mini_obj_timer;
    [SerializeField] private float timer_multiplier = 3f;
    public float mini_obj_speed;
    [SerializeField] private float smooth_motion = 1f;

    [SerializeField] private Transform contr;
    public float contr_pos;
    public float contr_pos_start = 0.0575f;
    [SerializeField] private float contr_size = 0.1f;
    [SerializeField] private float contr_power = 0.5f;
    public float contr_progress;
    public float contr_pull_vel;
    [SerializeField] private float contr_pull_power = 0.01f;
    [SerializeField] private float contr_gravity = 0.005f;
    [SerializeField] private float contr_progress_degrade = 0.1f;

    [SerializeField] Transform progress_bar_container;

    public bool pause = false;

    [SerializeField] float fail_time = 10f;
    

    // Update is called once per frame
    void Update()
    {
        if (pause){
            return;
        }

       Mini_Controller();
       Player_Control_Mini();
       ProgressCheck();
    }


    void Mini_Controller(){

        mini_obj_timer -= Time.deltaTime;

        if (mini_obj_timer < 0f){
            mini_obj_timer = UnityEngine.Random.value * timer_multiplier;

            mini_obj_des = UnityEngine.Random.value;

        }

        if (mini_obj_des < contr_pos_start){
            mini_obj_des = contr_pos_start;
        }

        if (mini_obj_des > 1f - contr_pos_start){
            mini_obj_des = 1f - contr_pos_start;
        }

        mini_obj_pos = Mathf.SmoothDamp(mini_obj_pos, mini_obj_des, ref mini_obj_speed, smooth_motion);
        mini_objective.position = Vector3.Lerp(bottom_Pivot.position, top_Pivot.position, mini_obj_pos);
    }

    void Player_Control_Mini(){

        if (Input.GetMouseButton(0)){
            contr_pull_vel += contr_pull_power * Time.deltaTime;
            //Debug.Log("Pressed primary button.");
        }

        contr_pull_vel -= contr_gravity * Time.deltaTime;
        contr_pos += contr_pull_vel;

        if (contr_pos <= contr_pos_start && contr_pull_vel < 0f){
            contr_pull_vel = 0f;
        }

        if (contr_pos >= 1f - contr_pos_start && contr_pull_vel > 0f){
            contr_pull_vel = 0f;
        }

        contr_pos = Mathf.Clamp(contr_pos, contr_size / 2, 1 - contr_size / 2);
        contr.position = Vector3.Lerp(bottom_Pivot.position, top_Pivot.position, contr_pos);
    }

    void ProgressCheck(){
        
        Vector3 v3 = progress_bar_container.localScale;
        v3.y = contr_progress;
        progress_bar_container.localScale = v3;

        float min = contr_pos - contr_size / 2;
        float max = contr_pos + contr_size / 2;

        if (min < mini_obj_pos && mini_obj_pos < max){
            contr_progress += contr_power * Time.deltaTime;

        } else{
            contr_progress -= contr_progress_degrade * Time.deltaTime;

            fail_time -= Time.deltaTime;

            if (fail_time < 0f){
                Lose();
            }

        }

        if (contr_progress >= 1f){
            Win();
        }

        contr_progress = Mathf.Clamp(contr_progress, 0f, 1f);
        //Debug.Log(fail_time);
    }

    private void Lose(){
        pause = true;

    }

    private void Win(){
        pause = true;

    }
}
